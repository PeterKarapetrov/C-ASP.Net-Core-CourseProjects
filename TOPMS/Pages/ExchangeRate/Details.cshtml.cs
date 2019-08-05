using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.ExchangeRate
{
    public class DetailsModel : PageModel
    {
        private readonly TOPMSContext _context;

        public DetailsModel(TOPMSContext context)
        {
            _context = context;
        }

        public Models.ExchangeRate ExchangeRate { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExchangeRate = await _context.ExchangeRates.FirstOrDefaultAsync(m => m.Id == id);

            if (ExchangeRate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
