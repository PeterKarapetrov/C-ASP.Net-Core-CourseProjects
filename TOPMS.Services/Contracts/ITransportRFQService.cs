using TOPMS.BindimgModels;
using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface ITransportRFQService
    {
        void AddTransportRFQ(TransportRFQCreateModel TransportRFQ);

        TransportRFQ GetTransportRFQ(string id);
        void EditTransportRFQ(TransportRFQCreateModel transportRFQModel, string id);
        TransportRFQCreateModel CreateModelFrom(string id);
    }
}
