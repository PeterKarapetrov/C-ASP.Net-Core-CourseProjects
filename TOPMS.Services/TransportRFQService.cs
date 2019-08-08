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
                Transport = transportRequired,
                Service = serviceRequired,
                ShipmentReadyDate = transportRFQModel.ShipmentReadyDate,
                RequestDeliveryDate = transportRFQModel.RequestDelieverDate,
                Status = status,
                SpecialRequirements = transportRFQModel.SpecialRequirements
                //Packaging = packaging
            };
        }
    }
}
