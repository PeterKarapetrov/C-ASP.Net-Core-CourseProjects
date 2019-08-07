using System;
using System.Collections.Generic;
using System.Text;
using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface ICompanyServiceService
    {
        void AddCompanyService(List<string> serviceNameList, List<string> serviceIdList, string companyId);

        IList<Models.CompanyService> GetCompanyServices(string companyId);

        void DeleteCompanyAllServices(string id);

        string GetCompanyServicesAsString(string companyId);
    }
}
