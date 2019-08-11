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
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ITransportRFQService _transportRFQService;

        public CreateModel(TOPMSContext context, ITransportRFQService transportRFQService)
        {
            _context = context;
            _transportRFQService = transportRFQService;
        }

        public IActionResult OnGetAsync()
        {
            ViewData["Material"] = new SelectList(_context.Materials, "Id", "Name");
            ViewData["Service"] = new SelectList(_context.Services, "Id", "Name");
            ViewData["Transport"] = new SelectList(_context.Transports, "Id", "Name");
            ViewData["From"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanySupplier"), "Id", "Name");
            ViewData["To"] = new SelectList(_context.Companies.Where(c => c.CompanyType.ToString() == "CompanyClient"), "Id", "Name");

            return Page();
        }

        public Models.TransportRFQ TransportRFQ { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string MaterialId { get; set; }
        public string ServiceId { get; set; }
        public string StatusId { get; set; }
        public string TransportId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            TransportRFQ.MaterialId = MaterialId;
            TransportRFQ.ServiceId = ServiceId;
            TransportRFQ.StatusId = _context.Status.FirstOrDefault(s => s.Name == "Submitted").Id;
            TransportRFQ.TransportId = TransportId;
            TransportRFQ.FromId = FromId;
            TransportRFQ.ToId = ToId;

            _context.TransportRFQs.Add(TransportRFQ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}