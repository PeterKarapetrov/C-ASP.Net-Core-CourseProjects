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
    public class CompanyService : ICompanyService
    {
        private readonly TOPMSContext _context;

        public CompanyService(TOPMSContext context)
        {
            _context = context;
        }
        public Company GetCompanyById(string companyId)
        {
            return _context.Companies.FirstOrDefault(m => m.Id == companyId);
        }
    }
}
