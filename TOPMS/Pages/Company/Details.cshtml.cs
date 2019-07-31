using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public DetailsModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public TOPMS.Models.Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
