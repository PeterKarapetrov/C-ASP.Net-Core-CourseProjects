using System.Collections.Generic;
using System.Linq;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Services
{
    public class CompanyServiceService : ICompanyServiceService
    {
        private readonly TOPMSContext _context;

        public CompanyServiceService(TOPMSContext context)
        {
            _context = context;
        }

        public void AddCompanyService(List<string> serviceNamesList, List<string> serviceIdsList, string companyId)
        {
            for (int i = 0; i < serviceIdsList.Count; i++)
            {
                if (serviceNamesList[i] == "true")
                {
                    var companyService = new Models.CompanyService(companyId, serviceIdsList[i]);
                    _context.CompanyServices.Add(companyService);
                }
            }
        }

        public void DeleteCompanyAllServices(string id)
        {
            var companyServices = GetCompanyServices(id);
            _context.CompanyServices.RemoveRange(companyServices);
        }

        public IList<Models.CompanyService> GetCompanyServices(string companyId)
        {
            return _context.CompanyServices.Where(cs => cs.CompanyId == companyId).ToList();
        }
    }
}
