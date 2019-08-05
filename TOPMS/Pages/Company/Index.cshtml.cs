using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TOPMS.Models;
using TOPMS.Data;


namespace TOPMS.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(TOPMSContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Models.Company> Company { get; set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Forwarder"))
            {
                var userId = _userManager.GetUserId(User);
                var forwarderUser = await _userManager.FindByIdAsync(userId);

                Company = await _context.Companies.Where(c => c.AppUsers.Contains(forwarderUser)).ToListAsync();
            }
            else if (User.IsInRole("Admin") || User.IsInRole("Approver") || User.IsInRole("User"))
            {
                Company = await _context.Companies.ToListAsync();
            }
            else
            {
                Company = new List<Models.Company>();
            }
            
        }
    }
}
