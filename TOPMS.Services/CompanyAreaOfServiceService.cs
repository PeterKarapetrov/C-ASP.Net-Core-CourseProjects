using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class CompanyAreaOfServiceService : ICompanyAreaOfServiceService
    {
        private readonly TOPMSContext _context;

        public CompanyAreaOfServiceService(TOPMSContext context)
        {
            _context = context;
        }

        public void AddAreaOfService(List<string> areasIdsList, string companyId)
        {
            for (int i = 0; i < areasIdsList.Count; i++)
            {
                var companyAreaOfService = new Models.CompanyAreaOfService(companyId, areasIdsList[i]);
                _context.CompanyAreaOfServices.Add(companyAreaOfService);
            }
        }

        public void DeleteCompanyAreaOfServices(string id)
        {
            var companyAreaOfServices = GetCompanyAreaOfServices(id);
            _context.CompanyAreaOfServices.RemoveRange(companyAreaOfServices);
        }

        public IList<CompanyAreaOfService> GetCompanyAreaOfServices(string companyId)
        {
            return _context.CompanyAreaOfServices.Where(cs => cs.CompanyId == companyId).ToList();
        }

        public string GetCompanyAreaOfServicesAsString(string companyId)
        {
            var transportNames = _context.CompanyAreaOfServices
                .Include(ca => ca.AreaOfService)
                .Where(ca => ca.CompanyId == companyId)
                .OrderBy(a => a.AreaOfService.Name)
                .ThenBy(a => a.AreaOfServiceId)
                .Select(a => a.AreaOfService.Name)
                .ToList();

            return String.Join(", ", transportNames);
        }
    }
}
