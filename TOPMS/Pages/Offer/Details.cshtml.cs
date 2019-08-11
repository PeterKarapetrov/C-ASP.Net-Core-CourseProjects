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
    public class DetailsModel : PageModel
    {
        private readonly TOPMSContext _context;

        public DetailsModel(TOPMSContext context)
        {
            _context = context;
        }

        public Models.Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = await _context.Offers
                .Include(o => o.TransportRFQ)
                .Include(o => o.TransportRFQ.From)
                .Include(o => o.TransportRFQ.To)
                .Include(o => o.TransportRFQ.Material)
                .Include(o => o.TransportRFQ.Service)
                .Include(o => o.TransportRFQ.Transport)
                .Include(o => o.AppUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Offer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
