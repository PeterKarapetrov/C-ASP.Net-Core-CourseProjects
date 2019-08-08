using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.CompanyAreaOfService
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ICompanyService _companyService;
        private readonly ICompanyAreaOfServiceService _companyAreaOfServiceService;
        private readonly IAreaOfServiceService _areaOfServiceService;

        public CreateModel(TOPMSContext context,
            ICompanyService companyService,
            ICompanyAreaOfServiceService companyAreaOfServiceService,
            IAreaOfServiceService areaOfServiceService)
        {
            _context = context;
            _companyService = companyService;
            _companyAreaOfServiceService = companyAreaOfServiceService;
            _areaOfServiceService = areaOfServiceService;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AreaOfServices = _areaOfServiceService.GetAllAreaOfService();

            return Page();
        }

        [BindProperty]
        public IList<Models.AreaOfService> AreaOfServices { get; set; }

        [BindProperty]
        public IList<string> AreChecked { get; set; }

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


            _companyAreaOfServiceService.DeleteCompanyAreaOfServices(id);
            _companyAreaOfServiceService.AddAreaOfService(AreChecked.ToList(), id);

            await _context.SaveChangesAsync();

            return Redirect($"/CompanyService/Create?id={id}");
        }
    }
}