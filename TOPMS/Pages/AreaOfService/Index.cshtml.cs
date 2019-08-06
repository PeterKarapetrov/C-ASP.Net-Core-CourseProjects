using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.AreaOfService
{
    public class IndexModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly IUserService _userService;

        public IndexModel(TOPMSContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IList<Models.AreaOfService> AreaOfService { get;set; }

        public async Task OnGetAsync()
        {
            AreaOfService = await _context.AreaOfService.ToListAsync();
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
