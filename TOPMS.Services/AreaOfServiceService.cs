using System.Collections.Generic;
using System.Linq;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class AreaOfServiceService : IAreaOfServiceService
    {
        private readonly TOPMSContext _context;

        public AreaOfServiceService(TOPMSContext context)
        {
            _context = context;
        }
        public IList<Models.AreaOfService> GetAllAreaOfService()
        {
            return _context.AreaOfService
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Id)
                .ToList();
        }
    }
}
