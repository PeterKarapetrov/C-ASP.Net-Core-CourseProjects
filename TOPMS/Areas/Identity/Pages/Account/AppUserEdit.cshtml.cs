using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TOPMS.Enums;
using TOPMS.Models;

namespace TOPMS.Areas.Identity.Pages.Account
{
    public class AppUserEditModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        public AppUserEditModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger
            /*IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            /*_emailSender = emailSender*/
        }

        [BindProperty]
        public EditAppUserModel EditAppUser { get; set; }

        public string ReturnUrl { get; set; }
        public class EditAppUserModel
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
            [Display(Name = "Role")]
            public string Role { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {   
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = await _userManager.FindByIdAsync(id);

            EditAppUser = new EditAppUserModel
            {
               Id = userFromDb.Id,
               UserName = userFromDb.UserName,
               Email = userFromDb.Email,
               PhoneNumber = userFromDb.PhoneNumber,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userRoleValue = int.Parse(EditAppUser.Role);
            string userRole = Enum.GetName(typeof(AppRoleEnum), userRoleValue);
            var user = await _userManager.FindByIdAsync(EditAppUser.Id);

            // TODO check if user has this role already

            try
            {
                if (userRole != "")
                {
                    await _userManager.AddToRoleAsync(user, userRole);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(EditAppUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AppUsers");
        }

        private bool UserExists(string id)
        {
            return _userManager.Users.Any(u => u.Id == id);
        }
    }
}