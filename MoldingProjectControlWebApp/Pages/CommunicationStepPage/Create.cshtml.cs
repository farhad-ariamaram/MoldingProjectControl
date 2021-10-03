﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.CommunicationStepPage
{
    public class CreateModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public CreateModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FldImplementationStepsId"] = new SelectList(_context.TblImplementationSteps, "FldImplementationStepsId", "FldImplementationStepsTxt");
            ViewData["FldImplementationStepsRelatedId"] = new SelectList(_context.TblImplementationSteps, "FldImplementationStepsId", "FldImplementationStepsTxt");
            ViewData["FldTypeOfCommunicationStepId"] = new SelectList(_context.TblTypeOfCommunicationSteps, "FldTypeOfCommunicationStepId", "FldTypeOfCommunicationStepTxt");
            return Page();
        }

        [BindProperty]
        public TblCommunicationStep TblCommunicationStep { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblCommunicationSteps.Add(TblCommunicationStep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
