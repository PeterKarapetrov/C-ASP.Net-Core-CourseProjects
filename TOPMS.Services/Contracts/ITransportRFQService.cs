using TOPMS.BindimgModels;
using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface ITransportRFQService
    {
        TransportRFQ CreateNewRFQFromModel(TransportRFQCreateModel TransportRFQ);

        void AddTransportRFQ(TransportRFQ transportRFQ);
    }
}
