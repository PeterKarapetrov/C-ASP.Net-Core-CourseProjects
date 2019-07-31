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
        ViewData["TransportRFQId"] = new SelectList(_context.TransportRFQs, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
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