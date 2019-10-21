using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_2.Data;

namespace Test_2.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly Test_2.Data.ApplicationDbContext _context;

        public CreateModel(Test_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AID"] = new SelectList(_context.Audit, "AID", "AID");
        ViewData["DID"] = new SelectList(_context.Department, "DID", "DID");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}