﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;

namespace TOPMS.Pages.CompanyTransport
{
    public class CreateModel : PageModel
    {
        private readonly TOPMSContext _context;
        private readonly ICompanyService _companyService;
        private readonly ICompanyTransportService _companyTranportService;
        private readonly ITransportService _transportService;

        public CreateModel(TOPMSContext context,
            ICompanyService companyService,
            ICompanyTransportService companyTranportService,
            ITransportService transportService)
        {
            _context = context;
            _companyService = companyService;
            _companyTranportService = companyTranportService;
            _transportService = transportService;
        }

        public IActionResult OnGet(string id)
        {
            _companyTranportService.DeleteCompanyTransports(id);
            _context.SaveChanges();
            Transports = _transportService.GetAllTransports();

            return Page();
        }

        [BindProperty]
        public IList<Models.Transport> Transports { get; set; }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            var company = _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            var transportNamesList = Request.Form["item.IsChecked"].ToList();
            var transportIdsList = Request.Form["item.Id"].ToList();
            _companyTranportService.AddCompanyTransport(transportNamesList, transportIdsList, id);

            await _context.SaveChangesAsync();

            return RedirectToPage($"/CompanyService/Create?id={id}");
        }
    }
}