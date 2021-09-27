using Microsoft.EntityFrameworkCore;
using PlateformServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { 
        }

        public DbSet<Plateform> Plateforms { get; set; }
    }
}
