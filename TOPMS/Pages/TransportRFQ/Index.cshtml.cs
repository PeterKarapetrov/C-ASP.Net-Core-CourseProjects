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
    public class IndexModel : PageModel
    {
        private readonly TOPMSContext _context;

        public IndexModel(TOPMSContext context)
        {
            _context = context;
        }

        public IList<Models.TransportRFQ> TransportRFQ { get;set; }

        public async Task OnGetAsync()
        {
            TransportRFQ = await _context.TransportRFQs
                .Include(t => t.Insurance)
                .Include(t => t.Material)
                .Include(t => t.Order)
                .Include(t => t.Service)
                .Include(t => t.Status)
                .Include(t => t.Transport)
                .Include(t => t.AppUser).ToListAsync();
        }
    }
}
