using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class CompanyTransportService : ICompanyTransportService
    {
        private readonly TOPMSContext _context;

        public CompanyTransportService(TOPMSContext context)
        {
            _context = context;
        }

        public void AddCompanyTransport(List<string> transportIdList, string companyId)
        {
            for (int i = 0; i < transportIdList.Count; i++)
            {
                var companyTransport = new CompanyTransport(companyId, transportIdList[i]);
                _context.CompanyTransports.Add(companyTransport);
            }
        }

        public void DeleteCompanyTransports(string id)
        {
            var companyTransports = GetCompanyTransports(id);
            _context.CompanyTransports.RemoveRange(companyTransports);
        }

        public IList<CompanyTransport> GetCompanyTransports(string companyId)
        {
            return _context.CompanyTransports.Where(ct => ct.CompanyId == companyId).ToList();
        }

        public string GetCompanyTransportsAsString(string companyId)
        {
            var transportNames = _context.CompanyTransports
                .Include(cs => cs.Transport)
                .OrderBy(cs => cs.Transport.Name)
                .ThenBy(cs => cs.TransportId)
                .Where(cs => cs.CompanyId == companyId)
                .Select(t => t.Transport.Name)
                .ToList();

            return String.Join(", ", transportNames);
        }
    }
}
