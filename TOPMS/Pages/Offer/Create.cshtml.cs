using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Models;

namespace TOPMS.Pages.Offer
{
    public class CreateModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public CreateModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        
        ViewData["TransportRFQId"] = "Gosho"/*new SelectList(_context.TransportRFQs, "Id", "Id")*/;
        ViewData["UserId"] = "Pesho"/*new SelectList(_context.AppUsers, "Id", "Id")*/;
        ViewData["Date"] = DateTime.UtcNow.Date;
        ViewData["ValidTill"] = DateTime.UtcNow.Date.AddDays(14);
            return Page();
        }

        [BindProperty]
        public TOPMS.Models.Offer Offer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Offers.Add(Offer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}