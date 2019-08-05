using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Models;

namespace TOPMS.Pages.Company
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(TOPMSContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Company Company { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var appUserId = _userManager.GetUserId(User);
            var appUser = await _userManager.FindByIdAsync(appUserId);

            Company.AppUsers.Add(appUser);
            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();

            string id = Company.Id;

            return Redirect($"./CompanyServices?id={id}");
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            if (!(User.IsInRole("Admin") || User.IsInRole("Forwarder") || User.IsInRole("Approver") || User.IsInRole("User")))
            {
                context.HttpContext.Response.Redirect("/Error");
                //TO DO implement Error page
            }

        }
    }
}