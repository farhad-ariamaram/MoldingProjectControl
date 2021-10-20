﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.WorkpiecePage
{
    public class CreateModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public CreateModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblWorkpiece TblWorkpiece { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblWorkpieces.Add(TblWorkpiece);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
