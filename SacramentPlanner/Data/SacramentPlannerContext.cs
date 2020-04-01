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


        //Found at https://stackoverflow.com/questions/34768976/specifying-on-delete-no-action-in-entity-framework-7
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

    }
}
