﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectManagementWebApp.Models;

namespace ProjectManagementWebApp.Pages.ProjectFileTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectManagementDBContext _context;

        public DeleteModel(ProjectManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblProjectFileType TblProjectFileType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectFileType = await _context.TblProjectFileTypes.FirstOrDefaultAsync(m => m.FldProjectFileTypeId == id);

            if (TblProjectFileType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblProjectFileType = await _context.TblProjectFileTypes.FindAsync(id);

            if (TblProjectFileType != null)
            {
                _context.TblProjectFileTypes.Remove(TblProjectFileType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
