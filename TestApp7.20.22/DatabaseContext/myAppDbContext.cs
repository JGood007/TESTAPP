using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp7._20._22.Models;

namespace TestApp7._20._22.DatabaseContext
{
    public class myAppDbContext: DbContext
    {
        public myAppDbContext(DbContextOptions<myAppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 



        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }

    }
}
