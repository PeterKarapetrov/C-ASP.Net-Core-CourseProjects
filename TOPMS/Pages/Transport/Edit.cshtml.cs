﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TOPMS.Data;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.Transport
{
    public class EditModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly IUserService _userService;

        public EditModel(TOPMSContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [BindProperty]
        public Models.Transport Transport { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transport = await _context.Transports.FirstOrDefaultAsync(m => m.Id == id);

            if (Transport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(Transport.Id))
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

        private bool TransportExists(string id)
        {
            return _context.Transports.Any(e => e.Id == id);
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
