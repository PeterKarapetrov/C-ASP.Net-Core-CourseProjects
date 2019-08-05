using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;


namespace TOPMS.Pages.AreaOfService
{
    public class _AreaOfServicePartialModel : PageModel
    {
        private readonly TOPMSContext _context;

        public _AreaOfServicePartialModel(TOPMSContext context)
        {
            _context = context;
        }

        public IList<Models.AreaOfService> AreaOfService { get;set; }

        public async Task OnGetAsync()
        {
            AreaOfService = await _context.AreaOfService.ToListAsync();
        }
    }
}
