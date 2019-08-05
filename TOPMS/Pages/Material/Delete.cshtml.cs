using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.Material
{
    public class DeleteModel : PageModel
    {
        private readonly TOPMSContext _context;

        public DeleteModel(TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);

            if (Material == null)
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

            Material = await _context.Materials.FindAsync(id);

            if (Material != null)
            {
                _context.Materials.Remove(Material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
