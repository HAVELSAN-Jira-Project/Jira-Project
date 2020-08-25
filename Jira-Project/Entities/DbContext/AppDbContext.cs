using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
