using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.Offer
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly IOfferService _offerService;

        public CreateModel(TOPMSContext context, IOfferService offerService)
        {
            _context = context;
            _offerService = offerService;
        }

        public IActionResult OnGet(string id)
        {
            ViewData["LoadingAddress"] = _offerService.GetLoadingAddress(id);
            ViewData["DeliveryAddress"] = _offerService.GetDeliveryAddress(id);
            ViewData["ShipmentReadyDate"] = _offerService.GetShipmentReadyDate(id);
            ViewData["RequestDeliveryDate"] = _offerService.GetRequestDeliveryDate(id);

            return Page();
        }

        [BindProperty]
        public Models.Offer Offer { get; set; }

        public async Task<IActionResult> OnPost(string id)
        {
            var creatorUserName = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Offer.TransportRFQId = id;
            Offer.AppUser = _context.AppUsers.FirstOrDefault(u => u.UserName == creatorUserName);
            _context.Offers.Add(Offer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}