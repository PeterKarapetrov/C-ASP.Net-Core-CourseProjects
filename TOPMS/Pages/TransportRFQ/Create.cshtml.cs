using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Models;

namespace TOPMS.Pages.TransportRFQ
{
    public class CreateModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public CreateModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InsuranceId"] = new SelectList(_context.Insurances, "Id", "Id");
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id");
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id");
        ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
        ViewData["TransportId"] = new SelectList(_context.Transports, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.TransportRFQ TransportRFQ { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TransportRFQs.Add(TransportRFQ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}