using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.BindimgModels;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.TransportRFQ
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ITransportRFQService _transportRFQService;

        public CreateModel(TOPMSContext context, ITransportRFQService transportRFQService)
        {
            _context = context;
            _transportRFQService = transportRFQService;
        }

        public IActionResult OnGet()
        {
            ViewData["MaterialCode"] = new SelectList(_context.Materials, "MaterialCode", "MaterialCode");
            ViewData["MaterialName"] = new SelectList(_context.Materials, "Name", "Name");
            ViewData["ServiceName"] = new SelectList(_context.Services, "Name", "Name");
            ViewData["StatusName"] = new SelectList(_context.Status, "Name", "Name");
            ViewData["TransportName"] = new SelectList(_context.Transports, "Name", "Name");
            ViewData["From"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanySupplier"), "Name", "Name");
            ViewData["To"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanyClient"), "Name", "Name");

            return Page();
        }

        [BindProperty]
        public TransportRFQCreateModel TransportRFQModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newRFQ = _transportRFQService.CreateNewRFQFromModel(TransportRFQModel);
            _transportRFQService.AddTransportRFQ(newRFQ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}