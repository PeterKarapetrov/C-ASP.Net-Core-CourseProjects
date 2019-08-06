using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class ServiceService : IServiceService
    {
        private readonly TOPMSContext _context;

        public ServiceService(TOPMSContext context)
        {
            _context = context;
        }
        public IList<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }
    }
}
