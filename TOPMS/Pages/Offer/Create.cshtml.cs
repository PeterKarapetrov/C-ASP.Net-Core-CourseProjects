using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Data;
using TOPMS.Models.BindingModels.Offers;
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
        public OfferViewModel OfferModel { get; set; }

        public IActionResult OnPost(string id)
        {
            var userName = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _offerService.AddOffer(OfferModel, id, userName);

            return RedirectToPage("./Index");
        }
    }
}