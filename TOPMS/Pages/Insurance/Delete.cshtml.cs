﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.Insurance
{
    public class DeleteModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public DeleteModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TOPMS.Models.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insurance = await _context.Insurances
                .Include(i => i.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Insurance == null)
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

            Insurance = await _context.Insurances.FindAsync(id);

            if (Insurance != null)
            {
                _context.Insurances.Remove(Insurance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
