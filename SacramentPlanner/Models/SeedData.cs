using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentPlanner.Data;
using System.Text;
using System.IO;

namespace SacramentPlanner.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentPlannerContext>>()))
            {
                // Look for any movies.
                if (context.Hymn.Any())
                {
                    return;   // DB has been seeded
                }

                string[] file = File.ReadLines(@"rushOrderPrices.txt").ToArray();

                for (int i = 0; i < file.Length; i++)
                {
                    context.Hymn.AddRange(
                        new Hymn
                        {
                            HymnID = i+1,
                            Hymn_Name = file[i]
                        });
                }

                //Add fake Members
                context.Directory.AddRange(
                    new Directory
                    {

                    }

                    );

                //Add fake Wards


                context.SaveChanges();
            }
        }





    }
}
