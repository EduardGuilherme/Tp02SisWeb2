using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp02SisWeb2.Models;

namespace Tp02SisWeb2.Data
{
    public class PortoContext:DbContext
    {
        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }

       
        
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
         {
             dbContextOptions.UseSqlServer("Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Containers;Data Source=DESKTOP-FACRE10");
         }
    }
}
