using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test_2.Data;

namespace Test_2.Pages.Audits
{
    public class IndexModel : PageModel
    {
        private readonly Test_2.Data.ApplicationDbContext _context;

        public IndexModel(Test_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Audit> Audit { get;set; }

        public async Task OnGetAsync()
        {
            var au = from m in _context.Audit select m;
            if (User.IsInRole("admin"))
            {

                au = au.Where(s => s.Save.Contains("admin"));

            }
            else if (User.IsInRole("slt"))
            {
                au = au.Where(s => s.Save.Contains("slt"));
            }
            else if (User.IsInRole("depthead"))
            {
                au = au.Where(s => s.Save.Contains("depthead"));
            }
            else
            {
                au = au.Where(s => s.Save.Contains(""));
            }
            Audit = await au.ToListAsync();
        }
        
    }
}
