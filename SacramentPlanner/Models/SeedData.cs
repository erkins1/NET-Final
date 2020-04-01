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

                //Add fake Wards
                context.Ward.AddRange(
                    new Ward
                    {
                        Ward_Name = "Salt Lake 106th",
                        Stake = "Utah 17th"
                    },
                    new Ward
                    {
                        Ward_Name = "Salt Lake 253rd",
                        Stake = "Utah 17th"
                    },
                    new Ward
                    {
                        Ward_Name = "Salt Lake 98th",
                        Stake = "Utah 17th"
                    }
                    );


                //Add fake Members
                context.Directory.AddRange(
                    new Directory
                    {
                        WardID = 1,
                        First_Name = "Joseph",
                        Last_Name = "Smith",
                        Age = 38,
                        Sex = "Male",
                        Calling = StakePresident
                    }

                    );

                //Add fake Wards


                context.SaveChanges();
            }
        }





    }
}
