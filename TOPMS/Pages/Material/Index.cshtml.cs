using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;

namespace TOPMS.Pages.Material
{
    public class IndexModel : PageModel
    {
        private readonly TOPMSContext _context;

        public IndexModel(TOPMSContext context)
        {
            _context = context;
        }

        public IList<Models.Material> Material { get;set; }

        public async Task OnGetAsync()
        {
            Material = await _context.Materials.ToListAsync();
        }
    }
}
