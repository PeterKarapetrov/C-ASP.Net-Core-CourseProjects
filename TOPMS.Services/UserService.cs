﻿using TOPMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using TOPMS.Models;


namespace TOPMS.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManger;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManger)
        {
            _userManager = userManager;
            _roleManger = roleManger;
        }

        public AppUser GetAppUserFromUserByName(string userName)
        {
            return _userManager.FindByNameAsync(userName).GetAwaiter().GetResult();
        }

        public bool UserHasRole(string userName)
        {
            var appUser = _userManager.FindByNameAsync(userName).GetAwaiter().GetResult();

            var appUserRoles = _userManager.GetRolesAsync(appUser).GetAwaiter().GetResult();

            if (appUserRoles.Count == 0)
            {
                return false;
            }

            return true;
        }

        public bool UserIsAdmin(string userName)
        {
            var appUser = _userManager.FindByNameAsync(userName).GetAwaiter().GetResult();

            var appUserRoles = _userManager.GetRolesAsync(appUser).GetAwaiter().GetResult();

            if (appUserRoles.Contains("Admin"))
            {
                return true;
            }

            return false;
        }
    }
}
