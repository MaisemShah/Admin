﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test_2.Data;

namespace Test_2.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly Test_2.Data.ApplicationDbContext _context;

        public DeleteModel(Test_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Department.FirstOrDefaultAsync(m => m.DID == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Department.FindAsync(id);

            if (Department != null)
            {
                _context.Department.Remove(Department);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
