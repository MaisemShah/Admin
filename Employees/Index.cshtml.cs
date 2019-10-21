using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test_2.Data;

namespace Test_2.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Test_2.Data.ApplicationDbContext _context;

        public IndexModel(Test_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee
                .Include(e => e.Audits)
                .Include(e => e.Departments).ToListAsync();
        }
    }
}
