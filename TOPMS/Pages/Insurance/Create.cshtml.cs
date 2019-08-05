using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Data;

namespace TOPMS.Pages.Insurance
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;

        public CreateModel(TOPMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Insurances.Add(Insurance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}