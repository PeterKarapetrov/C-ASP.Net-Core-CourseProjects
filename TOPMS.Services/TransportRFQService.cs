using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;
using TOPMS.BindimgModels;
using TOPMS.Data;
using TOPMS.Enums;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class TransportRFQService : ITransportRFQService
    {
        private readonly TOPMSContext _context;

        public TransportRFQService(TOPMSContext context)
        {
            _context = context;
        }

        public void AddTransportRFQ(TransportRFQ transportRFQ)
        {
            _context.TransportRFQs.Add(transportRFQ);
        }

        public TransportRFQCreateModel CreateModelFrom(string id)
        {
            var transporRFQ = GetTransportRFQ(id);

            if (transporRFQ == null)
            {
                throw new Exception("Not Found"); // TO DO Refactor
            }

            return new TransportRFQCreateModel()
            {
                UserName = transporRFQ.AppUser.UserName,
                Id = transporRFQ.Id,
                Date = transporRFQ.Date,
                NumberOfPackages = transporRFQ.NumberOfPackages,
                PackageDimensions = transporRFQ.PackageDimention,
                Volume = transporRFQ.Volume,
                Weight = transporRFQ.Weight,
                ShipmentReadyDate = transporRFQ.ShipmentReadyDate,
                RequestDelieverDate = transporRFQ.RequestDeliveryDate,
                OrderId = transporRFQ.OrderId,
                InsuranceId = transporRFQ.InsuranceId,
                Offers = transporRFQ.Offers.Count(),
            };
        }

        public TransportRFQ CreateNewRFQFromModel(TransportRFQCreateModel transportRFQModel)
        {
            var appUser = _context.AppUsers.FirstOrDefault(u => u.UserName == transportRFQModel.UserName);
            var companySupplier = _context.Companies.FirstOrDefault(c => c.Name == transportRFQModel.FromName);
            var companyClient = _context.Companies.FirstOrDefault(c => c.Name == transportRFQModel.ToName);
            var material = _context.Materials.FirstOrDefault(m => m.Name == transportRFQModel.MaterialName);
            var packaging = Enum.Parse<Packaging>(transportRFQModel.Packaging);
            var transportRequired = _context.Transports.FirstOrDefault(t => t.Name == transportRFQModel.TransportRequired);
            var serviceRequired = _context.Services.FirstOrDefault(t => t.Name == transportRFQModel.ServiceRequired);
            var status = _context.Status.FirstOrDefault(t => t.Name == transportRFQModel.Status);
            
            return new TransportRFQ()
            {
                AppUser = appUser,
                Date = transportRFQModel.Date,
                From = companySupplier,
                To = companyClient,
                Material = material,
                NumberOfPackages = transportRFQModel.NumberOfPackages,
                PackageDimention = transportRFQModel.PackageDimensions,
                Volume = transportRFQModel.Volume,
                Weight = transportRFQModel.Weight,
                Transport = transportRequired,
                Service = serviceRequired,
                ShipmentReadyDate = transportRFQModel.ShipmentReadyDate,
                RequestDeliveryDate = transportRFQModel.RequestDelieverDate,
                Status = status,
                SpecialRequirements = transportRFQModel.SpecialRequirements,
                Packaging = packaging
            };
        }

        public void EditTransportRFQ(TransportRFQCreateModel transportRFQModel, string id)
        {
            var TransportRFQ = this.GetTransportRFQ(id);

            TransportRFQ.AppUser = _context.AppUsers.FirstOrDefault(u => u.UserName == transportRFQModel.UserName);
            TransportRFQ.From = _context.Companies.FirstOrDefault(c => c.Name == transportRFQModel.FromName);
            TransportRFQ.Date = transportRFQModel.Date;
            TransportRFQ.To = _context.Companies.FirstOrDefault(c => c.Name == transportRFQModel.ToName);
            TransportRFQ.Material =_context.Materials.FirstOrDefault(m => m.Name == transportRFQModel.MaterialName);
            TransportRFQ.Packaging = Enum.Parse<Packaging>(transportRFQModel.Packaging);
            TransportRFQ.NumberOfPackages = transportRFQModel.NumberOfPackages;
            TransportRFQ.PackageDimention = transportRFQModel.PackageDimensions;
            TransportRFQ.Volume = transportRFQModel.Volume;
            TransportRFQ.Weight = transportRFQModel.Weight;
            TransportRFQ.Transport = _context.Transports.FirstOrDefault(t => t.Name == transportRFQModel.TransportRequired);
            TransportRFQ.Service = _context.Services.FirstOrDefault(t => t.Name == transportRFQModel.ServiceRequired);
            TransportRFQ.ShipmentReadyDate = transportRFQModel.ShipmentReadyDate;
            TransportRFQ.RequestDeliveryDate = transportRFQModel.RequestDelieverDate;
            TransportRFQ.SpecialRequirements = transportRFQModel.SpecialRequirements;
            TransportRFQ.Status = _context.Status.FirstOrDefault(t => t.Name == transportRFQModel.Status);

            _context.Attach(TransportRFQ).State = EntityState.Modified;
        }

        public TransportRFQ GetTransportRFQ(string id)
        {
            return _context.TransportRFQs
                .Include(t => t.Insurance)
                .Include(t => t.Material)
                .Include(t => t.Order)
                .Include(t => t.Service)
                .Include(t => t.Status)
                .Include(t => t.Transport)
                .Include(t => t.AppUser).FirstOrDefault(m => m.Id == id);
        }
    }
}
