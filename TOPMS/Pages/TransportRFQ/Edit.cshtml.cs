using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOPMS.BindimgModels;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.TransportRFQ
{
    public class EditModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ITransportRFQService _transportRFQService;

        public EditModel(TOPMSContext context, ITransportRFQService transportRFQService)
        {
            _context = context;
            _transportRFQService = transportRFQService;
        }

        [BindProperty]
        public TransportRFQCreateModel TransportRFQ { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransportRFQ = _transportRFQService.CreateModelFrom(id);
            ViewData["MaterialCode"] = new SelectList(_context.Materials, "MaterialCode", "MaterialCode");
            ViewData["MaterialName"] = new SelectList(_context.Materials, "Name", "Name");
            ViewData["ServiceName"] = new SelectList(_context.Services, "Name", "Name");
            ViewData["StatusName"] = new SelectList(_context.Status, "Name", "Name");
            ViewData["TransportName"] = new SelectList(_context.Transports, "Name", "Name");
            ViewData["From"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanySupplier"), "Name", "Name");
            ViewData["To"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanyClient"), "Name", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _transportRFQService.EditTransportRFQ(TransportRFQ, id);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportRFQExists(id))
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
