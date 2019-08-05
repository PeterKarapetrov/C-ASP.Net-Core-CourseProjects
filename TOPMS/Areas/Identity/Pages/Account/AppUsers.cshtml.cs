using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TOPMS.Models;

namespace TOPMS.Areas.Identity.Pages.Account
{
    public class AppUsersModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        public AppUsersModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger
            /*IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            /*_emailSender = emailSender*/
            ;
        }

        [BindProperty]
        public List<UserModel> Users { get; set; }

        public class UserModel
        {

            [Required]
            [Display(Name = "UserId")]
            public string Id { get; set; }

            [Required]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Phone]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "IsInRole")]
            public string Role { get; set; }
        }

        public async Task OnGetAsync()
        {
            Users = new List<UserModel>();

            var usersFromDb = await _userManager.Users.ToAsyncEnumerable().ToList();

            foreach (var user in usersFromDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
 
                var userModel = new UserModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = String.Join(',', roles)
                };

                Users.Add(userModel);
            }
        }
    }
}