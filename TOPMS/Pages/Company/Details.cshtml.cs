using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;
using TOPMS.Services;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ICompanyServiceService _companyServiceService;
        private readonly ICompanyTransportService _companyTransportService;
        private readonly ICompanyAreaOfServiceService _companyAreaOfServiceService;

        public DetailsModel(TOPMSContext context, 
            ICompanyServiceService companyServiceService,
            ICompanyTransportService companyTransportService,
            ICompanyAreaOfServiceService companyAreaOfServiceService)
        {
            _context = context;
            _companyServiceService = companyServiceService;
            _companyTransportService = companyTransportService;
            _companyAreaOfServiceService = companyAreaOfServiceService;
        }

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

            ViewData["CompanyServices"] = _companyServiceService.GetCompanyServicesAsString(id);
            ViewData["CompanyTransports"] = _companyTransportService.GetCompanyTransportsAsString(id);
            ViewData["CompanyAreaOfServices"] = _companyAreaOfServiceService.GetCompanyAreaOfServicesAsString(id);

            return Page();
        }
    }
}
