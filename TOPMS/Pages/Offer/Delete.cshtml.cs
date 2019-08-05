using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.Offer
{
    public class DeleteModel : PageModel
    {
        private readonly TOPMSContext _context;

        public DeleteModel(TOPMSContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = await _context.Offers.FindAsync(id);

            if (Offer != null)
            {
                _context.Offers.Remove(Offer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
