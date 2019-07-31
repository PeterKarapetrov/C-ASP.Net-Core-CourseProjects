using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.AreaOfService
{
    public class _AreaOfServicePartialModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public _AreaOfServicePartialModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public IList<TOPMS.Models.AreaOfService> AreaOfService { get;set; }

        public async Task OnGetAsync()
        {
            AreaOfService = await _context.AreaOfService.ToListAsync();
        }
    }
}
