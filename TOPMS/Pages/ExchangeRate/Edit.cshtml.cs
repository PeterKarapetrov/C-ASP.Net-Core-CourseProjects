using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.ExchangeRate
{
    public class EditModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public EditModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TOPMS.Models.ExchangeRate ExchangeRate { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExchangeRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeRateExists(ExchangeRate.Id))
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

        private bool ExchangeRateExists(string id)
        {
            return _context.ExchangeRates.Any(e => e.Id == id);
        }
    }
}
