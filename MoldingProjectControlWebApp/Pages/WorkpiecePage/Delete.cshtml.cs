﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoldingProjectControlWebApp.Models;

namespace MoldingProjectControlWebApp.Pages.WorkpiecePage
{
    public class DeleteModel : PageModel
    {
        private readonly MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext _context;

        public DeleteModel(MoldingProjectControlWebApp.Models.MoldingProjectControlDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblWorkpiece TblWorkpiece { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblWorkpiece = await _context.TblWorkpieces.FirstOrDefaultAsync(m => m.FldWorkpieceId == id);

            if (TblWorkpiece == null)
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

            TblWorkpiece = await _context.TblWorkpieces.FindAsync(id);

            if (TblWorkpiece != null)
            {
                _context.TblWorkpieces.Remove(TblWorkpiece);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
