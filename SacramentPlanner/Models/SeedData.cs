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

                string[] file = File.ReadLines("Resources\\Hymns.txt").ToArray();

                for (int i = 0; i < file.Length; i++)
                {
                    context.Hymn.AddRange(
                        new Hymn
                        {
                            Hymn_Number = i+1,
                            Hymn_Name = file[i]
                        });
                }

                context.SaveChanges();

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
                    });

                context.SaveChanges();

                //Add fake Members
                context.Directory.AddRange(
                    new Directory
                    {
                        WardID = 1,
                        First_Name = "Joseph",
                        Last_Name = "Smith",
                        Age = 38,
                        Sex = Gender.Male,
                        Calling = Title.Bishop
                    },
                    new Directory
                    {
                        WardID = 1,
                        First_Name = "Emma",
                        Last_Name = "Smith",
                        Age = 58,
                        Sex = Gender.Female,
                    },
                    new Directory
                    {
                        WardID = 2,
                        First_Name = "Brigham",
                        Last_Name = "Young",
                        Age = 63,
                        Sex = Gender.Male,
                        Calling = Title.WardFirstCouncellor
                    },
                    new Directory
                    {
                        WardID = 1,
                        First_Name = "Russell",
                        Last_Name = "Nelson",
                        Age = 88,
                        Sex = Gender.Male,
                        Calling = Title.StakePresident
                    },
                    new Directory
                    {
                        WardID = 1,
                        First_Name = "Dallin",
                        Last_Name = "Oaks",
                        Age = 90,
                        Sex = Gender.Male,
                        Calling = Title.StakeFirstCouncellor
                    },
                    new Directory
                    {
                        WardID = 2,
                        First_Name = "Jean",
                        Last_Name = "Bingham",
                        Age = 54,
                        Sex = Gender.Female,
                    });

                context.SaveChanges();
            }
        }





    }
}
