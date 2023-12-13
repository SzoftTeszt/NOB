using Microsoft.EntityFrameworkCore;
using NobelConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelConsole.Data
{
    class AdatContext :DbContext
    {
        public DbSet<Adat> Nobel { get; set; }
        public DbSet<Fajta> Tipusok { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=NobelData;Trusted_Connection=true");
        }
    }
}
