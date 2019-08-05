using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.Insurance
{
    public class EditModel : PageModel
    {
        private readonly TOPMSContext _context;

        public EditModel(TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insurance = await _context.Insurances
                .Include(i => i.AppUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Insurance == null)
            {
                return NotFound();
            }
           ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(Insurance.Id))
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

        private bool InsuranceExists(string id)
        {
            return _context.Insurances.Any(e => e.Id == id);
        }
    }
}
