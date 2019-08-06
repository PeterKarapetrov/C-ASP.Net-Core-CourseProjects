using System;
using System.Collections.Generic;
using System.Text;
using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface ITransportService
    {
        IList<Transport> GetAllTransports();
    }
}
