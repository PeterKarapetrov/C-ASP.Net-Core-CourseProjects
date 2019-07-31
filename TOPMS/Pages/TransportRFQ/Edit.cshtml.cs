using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.TransportRFQ
{
    public class EditModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public EditModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TransportRFQ TransportRFQ { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransportRFQ = await _context.TransportRFQs
                .Include(t => t.Insurance)
                .Include(t => t.Material)
                .Include(t => t.Order)
                .Include(t => t.Service)
                .Include(t => t.Status)
                .Include(t => t.Transport)
                .Include(t => t.User).FirstOrDefaultAsync(m => m.Id == id);

            if (TransportRFQ == null)
            {
                return NotFound();
            }
           ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Id");
           ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id");
           ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
           ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id");
           ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
           ViewData["TransportId"] = new SelectList(_context.Transports, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransportRFQ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportRFQExists(TransportRFQ.Id))
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

        private bool TransportRFQExists(string id)
        {
            return _context.TransportRFQs.Any(e => e.Id == id);
        }
    }
}
