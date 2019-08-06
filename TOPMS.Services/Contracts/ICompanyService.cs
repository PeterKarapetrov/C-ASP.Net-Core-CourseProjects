using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface ICompanyService
    {
        Company GetCompanyById(string comnyId);
    }
}
