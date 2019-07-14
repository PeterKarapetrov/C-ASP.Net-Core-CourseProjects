using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Views.Roles
{
    public class EditModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public EditModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (Role == null)
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

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
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

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
