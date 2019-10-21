using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test_2.Data;

namespace Test_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test_2.Data.Audit> Audit { get; set; }
        public DbSet<Test_2.Data.Department> Department { get; set; }
        public DbSet<Test_2.Data.Employee> Employee { get; set; }
    }
}
