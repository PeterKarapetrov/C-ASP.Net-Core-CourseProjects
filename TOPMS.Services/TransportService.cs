using System.Collections.Generic;
using System.Linq;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class TransportService : ITransportService
    {
        private readonly TOPMSContext _context;

        public TransportService(TOPMSContext context)
        {
            _context = context;
        }

        public IList<Transport> GetAllTransports()
        {
            return _context.Transports
                .OrderByDescending(t => t.Name)
                .ThenByDescending(t => t.Id)
                .ToList();
        }
    }
}
