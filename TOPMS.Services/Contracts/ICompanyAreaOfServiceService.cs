using System;
using System.Collections.Generic;
using System.Text;

namespace TOPMS.Services.Contracts
{
    public interface ICompanyAreaOfServiceService
    {
        void AddAreaOfService(List<string> areasIdList, string companyId);

        IList<Models.CompanyAreaOfService> GetCompanyAreaOfServices(string companyId);

        void DeleteCompanyAreaOfServices(string id);

        string GetCompanyAreaOfServicesAsString(string companyId);
    }
}
