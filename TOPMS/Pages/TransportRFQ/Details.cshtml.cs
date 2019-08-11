using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.TransportRFQ
{
    public class DetailsModel : PageModel
    {
        private readonly TOPMSContext _context;

        public DetailsModel(TOPMSContext context)
        {
            _context = context;
        }

        public Models.TransportRFQ TransportRFQ { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransportRFQ = await _context.TransportRFQs
                .Include(t => t.Insurance)
                .Include(t => t.Material)
                .Include(t => t.Order)
                .Include(t => t.Service)
                .Include(t => t.Status)
                .Include(t => t.Transport)
                .Include(t => t.Offers)
                .Include(t => t.AppUser)
                .Include(t => t.From)
                .Include(t => t.To).FirstOrDefaultAsync(m => m.Id == id);

            if (TransportRFQ == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
