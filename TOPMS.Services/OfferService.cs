using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOPMS.Data;
using TOPMS.Models.BindingModels.Offers;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class OfferService : IOfferService
    {
        private readonly TOPMSContext _context;

        public OfferService(TOPMSContext context)
        {
            _context = context;
        }

        public string GetRequestDeliveryDate(string transportRFQId)
        {
            var date = _context.TransportRFQs
                   .FirstOrDefault(t => t.Id == transportRFQId)
                   .RequestDeliveryDate
                   .ToString();

            return $"RequestDeliveryDate - { date }";
        }

        public string GetDeliveryAddress(string transortRFQId)
        {
            var transportRFQ = _context.TransportRFQs
                .Include(t => t.From)
                .Include(t => t.To).FirstOrDefault(t => t.Id == transortRFQId);

            var sb = new StringBuilder();
            sb.Append($"{transportRFQ.From.Country.ToString()}, ");
            sb.Append($"{transportRFQ.From.ZIPCode.ToString()} ");
            sb.Append($"{transportRFQ.From.City.ToString()}, ");
            sb.Append($"{transportRFQ.From.Address.ToString()}, ");

            return sb.ToString();
        }

        public string GetLoadingAddress(string transortRFQId)
        {
            var transportRFQ = _context.TransportRFQs
                .Include(t => t.From)
                .Include(t => t.To).FirstOrDefault(m => m.Id == transortRFQId);

            var sb = new StringBuilder();
            sb.Append($"{transportRFQ.To.Country.ToString()}, ");
            sb.Append($"{transportRFQ.To.ZIPCode.ToString()} ");
            sb.Append($"{transportRFQ.To.City.ToString()}, ");
            sb.Append($"{transportRFQ.To.Address.ToString()}, ");

            return sb.ToString();
        }

        public string GetShipmentReadyDate(string transportRFQId)
        {
            var date = _context.TransportRFQs
                    .FirstOrDefault(t => t.Id == transportRFQId)
                    .ShipmentReadyDate
                    .ToString();

            return $"ShipmentReadyDate - { date } ";
        }

        public void AddOffer(OfferViewModel offerModel, string transportRFQId, string userName)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.UserName == userName);

            var offer = new Models.Offer()
            {
                AppUserId = user.Id,
                Date = offerModel.Date,
                ValidTill = offerModel.ValidTill,
                TransportRFQId = transportRFQId,
                LoadingTime = offerModel.LoadingTime,
                DeliveryTime = offerModel.DeliveryTime,
                PriceOffered = offerModel.PriceOffered,
                Currency = offerModel.Currency,
                Comments = offerModel.Comments,
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public string GetTransportRFQData(string transportRFQId)
        {
            var transportRFQ = _context.TransportRFQs
               .Include(t => t.From)
               .Include(t => t.To).FirstOrDefault(m => m.Id == transportRFQId);

            var sb = new StringBuilder();
            sb.Append($"From: {transportRFQ.From.Country.ToString()}, ");
            sb.Append($"{transportRFQ.From.ZIPCode.ToString()} ");
            sb.Append($"{transportRFQ.From.City.ToString()} ");
            sb.Append($"--- To: {transportRFQ.To.Country.ToString()}, ");
            sb.Append($"{transportRFQ.To.ZIPCode.ToString()} ");
            sb.Append($"{transportRFQ.To.City.ToString()}, ");
            sb.Append($"{transportRFQ.NumberOfPackages.ToString()}- ");
            sb.Append($"{transportRFQ.Packaging.ToString()}, ");
            sb.Append($"{transportRFQ.Weight.ToString()}kg, ");
            sb.Append($"{transportRFQ.Volume.ToString()}cmb, ");

            return sb.ToString();
        }
    }
}
