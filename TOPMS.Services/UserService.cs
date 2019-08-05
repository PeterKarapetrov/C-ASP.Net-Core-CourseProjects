using TOPMS.Services.Contracts;
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

        public bool UserHasRole(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).GetAwaiter().GetResult(); ;

            var userRoles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();

            if (userRoles.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
