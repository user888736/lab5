using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace lab5.Models
{
    public class lab5Context : DbContext
    {
        public lab5Context(DbContextOptions<lab5Context> options)
            : base(options)
        {
        }

        public DbSet<lab5Item> lab5Items { get; set; }

    }
}
