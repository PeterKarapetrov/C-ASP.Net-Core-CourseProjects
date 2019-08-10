using TOPMS.Models.BindingModels.Offers;

namespace TOPMS.Services.Contracts
{
    public interface IOfferService
    {
        string GetLoadingAddress(string transortRFQId);

        string GetDeliveryAddress(string transortRFQId);

        string GetShipmentReadyDate(string transportRFQId);

        string GetRequestDeliveryDate(string transportRFQId);

        void AddOffer(OfferViewModel offerModel, string transportRFQId, string userName);

        string GetTransportRFQData(string transportRFQId);
    }
}
