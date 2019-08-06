using System;
using System.Collections.Generic;
using System.Text;

namespace TOPMS.Services.Contracts
{
    public interface ICompanyTransportService
    {
        void AddCompanyTransport(List<string> transportNameList, List<string> transportIdList, string companyId);

        IList<Models.CompanyTransport> GetCompanyTransports(string companyId);

        void DeleteCompanyTransports(string id);
    }
}
