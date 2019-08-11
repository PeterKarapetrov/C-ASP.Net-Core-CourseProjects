using System.ComponentModel.DataAnnotations;
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
        public Models.TransportRFQ TransportRFQ { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please choose RFQ Status")]
        public string StatusId { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");
            TransportRFQ = await _context.TransportRFQs.FirstOrDefaultAsync(t => t.Id == id);

            if (TransportRFQ == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TransportRFQ.StatusId = StatusId;
            _context.Attach(TransportRFQ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportRFQExists(TransportRFQ.Id))
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
