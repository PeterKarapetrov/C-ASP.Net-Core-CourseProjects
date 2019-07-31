using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public DetailsModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public TOPMS.Models.Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
