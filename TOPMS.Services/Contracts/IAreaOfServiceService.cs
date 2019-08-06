using System.Collections.Generic;

namespace TOPMS.Services.Contracts
{
    public interface IAreaOfServiceService
    {
        IList<Models.AreaOfService> GetAllAreaOfService();
    }
}
