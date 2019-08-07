using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;
using TOPMS.Enums;

namespace TOPMS.Pages.Company
{
    public class EditModel : PageModel
    {
        private readonly TOPMSContext _context;

        public EditModel(TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Company Company { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var companyType = Enum.GetName(typeof(CompanyType), Company.CompanyType);

            if (companyType == "Forwarder") // TODO change magic string
            {
                return Redirect($"/CompanyTransport/Create?id={Company.Id}");
            }

            return RedirectToPage("./Index");
        }

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
