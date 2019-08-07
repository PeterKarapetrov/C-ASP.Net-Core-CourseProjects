using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.CompanyService
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ICompanyService _companyService;
        private readonly ICompanyServiceService _companyServiceService;
        private readonly IServiceService _serviceService;

        public CreateModel(TOPMSContext context,
            ICompanyService companyService,
            ICompanyServiceService companyServiceService,
            IServiceService serviceService)
        {
            _context = context;
            _companyService = companyService;
            _companyServiceService = companyServiceService;
            _serviceService = serviceService;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _companyServiceService.DeleteCompanyAllServices(id);
            _context.SaveChanges();
            Services = _serviceService.GetAllServices();

            return Page();
        }

        [BindProperty]
        public IList<Models.Service> Services { get; set; }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            var company = _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            var serviceNamesList = Request.Form["item.IsChecked"].ToList();
            var serviceIdsList = Request.Form["item.Id"].ToList();
            _companyServiceService.AddCompanyService(serviceNamesList, serviceIdsList, id);

            await _context.SaveChangesAsync();

            return Redirect($"/Company/Details?id={id}");
        }
    }
}