using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.AreaOfService
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly IUserService _userService;

        public CreateModel(TOPMSContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.AreaOfService AreaOfService { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AreaOfService.Add(AreaOfService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            if (!_userService.UserIsAdmin(User.Identity.Name))
            {
                context.HttpContext.Response.Redirect("/ErrorNotAuthorized");
                //TO DO implement Error page
            }
        }
    }
}