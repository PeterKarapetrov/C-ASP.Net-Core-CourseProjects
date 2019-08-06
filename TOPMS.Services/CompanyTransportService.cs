using System.Collections.Generic;
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

        public void AddCompanyTransport(List<string> transportNameList, List<string> transportIdList, string companyId)
        {
            for (int i = 0; i < transportIdList.Count; i++)
            {
                if (transportNameList[i] == "true")
                {
                    var companyTransport = new CompanyTransport(companyId, transportIdList[i]);
                    _context.CompanyTransports.Add(companyTransport);
                }
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
    }
}
