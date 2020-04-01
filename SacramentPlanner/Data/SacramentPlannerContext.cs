using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Data
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext(DbContextOptions<SacramentPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Directory> Directory { get; set; }
        public DbSet<Ward> Ward { get; set; }
        public DbSet<Hymn> Hymn { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Agenda> Agenda { get; set; }

    }
}
