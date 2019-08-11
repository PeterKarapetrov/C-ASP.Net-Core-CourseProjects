using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.Offer
{
    public class EditModel : PageModel
    {
        private readonly TOPMSContext _context;

        public EditModel(TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = await _context.Offers
                .Include(o => o.TransportRFQ)
                .Include(o => o.AppUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Offer == null)
            {
                return NotFound();
            }

            ViewData["TransportRFQId"] = new SelectList(_context.TransportRFQs, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(Offer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfferExists(string id)
        {
            return _context.Offers.Any(e => e.Id == id);
        }
    }
}
