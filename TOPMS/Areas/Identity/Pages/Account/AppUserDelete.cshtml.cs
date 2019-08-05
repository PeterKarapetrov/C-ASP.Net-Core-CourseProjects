using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TOPMS.Models;

namespace TOPMS.Areas.Identity.Pages.Account
{
    public class AppUserDeleteModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        public AppUserDeleteModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            //ILogger<RegisterModel> logger
            /*IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_logger = logger;
            /*_emailSender = emailSender*/
        }

        [BindProperty]
        public DeleteAppUserModel DeleteAppUser { get; set; }

        public class DeleteAppUserModel
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
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = await _userManager.FindByIdAsync(id);

            DeleteAppUser = new DeleteAppUserModel
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

            var user = await _userManager.FindByIdAsync(DeleteAppUser.Id);

            // TODO check if user has this role already

            try
            {
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(DeleteAppUser.Id))
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
