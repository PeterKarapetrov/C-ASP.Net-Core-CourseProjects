using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Web.Providers.Entities;
using TOPMS.Models;

namespace TOPMS.Services.Contracts
{
    public interface IUserService
    {
        bool UserHasRole(string userName);

        AppUser GetAppUserFromUserByName(string userName);

        bool UserIsAdmin(string userName);
    }
}
