using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.Company
{
    public class CompanyServicesModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public CompanyServicesModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Company Company { get; set; }

        [BindProperty]
        public IList<Models.Service> Services { get; set; }

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

            Services = _context.Services.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var company = _context.Companies.FirstOrDefault();

            var checkBoxResultList = Request.Form["item.IsChecked"].ToList();
            var serviceIdList = Request.Form["item.Id"].ToList();

            for (int i = 0; i < serviceIdList.Count; i++)
            {
                if (checkBoxResultList[i] == "true")
                {
                    var companyService = new CompanyService(Company, serviceIdList[i]);
                    _context.CompanyServices.Add(companyService);
                }

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

            return RedirectToPage("./Index");
        }

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
