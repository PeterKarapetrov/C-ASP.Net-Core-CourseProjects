using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Pages.ExchangeRate
{
    public class IndexModel : PageModel
    {
        private readonly TOPMS.Models.TOPMSContext _context;

        public IndexModel(TOPMS.Models.TOPMSContext context)
        {
            _context = context;
        }

        public IList<TOPMS.Models.ExchangeRate> ExchangeRate { get;set; }

        public async Task OnGetAsync()
        {
            ExchangeRate = await _context.ExchangeRates.ToListAsync();
        }
    }
}
