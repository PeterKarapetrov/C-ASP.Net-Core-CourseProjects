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
        private readonly TOPMSContext _context;
        //private readonly IEmailSender _emailSender;

        public AppUsersModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            TOPMSContext context
            /*IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            /*_emailSender = emailSender*/
            ;
        }

        [BindProperty]
        public List<UserModel> Users { get; set; }

        public string ReturnUrl { get; set; }

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

        public async Task OnGetAsync(/*string returnUrl = null*/)
        {
            Users = new List<UserModel>();

            var usersFromDb = await _userManager.Users.ToAsyncEnumerable().ToList();

            foreach (var user in usersFromDb)
            {
                var sbRoles = new StringBuilder();
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
            //ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //if (ModelState.IsValid)
            //{
            //    var UsersList = await _userManager.Users.ToAsyncEnumerable().ToList();


            //    var user = new AppUser { UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.PhoneNumber };

            //    var adminsList = await _userManager.GetUsersInRoleAsync("Admin");

            //    //var result = await _userManager.CreateAsync(user, Input.Password);

            //    if (adminsList.Count == 0)
            //    {
            //        _userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }

            //    if (result.Succeeded)
            //    {
            //        _logger.LogInformation("User created a new account with password.");

            //        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //        //var callbackUrl = Url.Page(
            //        //    "/Account/ConfirmEmail",
            //        //    pageHandler: null,
            //        //    values: new { userId = user.Id, code = code },
            //        //    protocol: Request.Scheme);

            //        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
            //        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //        await _signInManager.SignInAsync(user, isPersistent: false);
            //        return LocalRedirect(returnUrl);
            //    }
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}