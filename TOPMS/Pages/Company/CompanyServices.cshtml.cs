using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;
using TOPMS.Data;

namespace TOPMS.Pages.Company
{
    public class CompanyServicesModel : PageModel
    {
        private readonly TOPMSContext _context;

        public CompanyServicesModel(TOPMSContext context)
        {
            _context = context;
        }


        [BindProperty]
        public IList<Models.Service> Services { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            Services = _context.Services.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var checkBoxResultList = Request.Form["item.IsChecked"].ToList();
            var serviceIdList = Request.Form["item.Id"].ToList();

            for (int i = 0; i < serviceIdList.Count; i++)
            {
                if (checkBoxResultList[i] == "true")
                {
                    var companyService = new CompanyService(id, serviceIdList[i]);
                    _context.CompanyServices.Add(companyService);
                }

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
