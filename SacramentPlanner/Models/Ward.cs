using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentPlanner.Models
{
    public class Ward
    {
        public int WardID { get; set; }

        public string Ward_Name { get; set; }

        public string Stake { get; set; }

    }
}