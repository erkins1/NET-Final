using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Hymn
    {
        public int HymnID { get; set; }
        public int Hymn_Number { get; set; }
        public string Hymn_Name { get; set; }

        [NotMapped]
        public string Hymn_Number_Name { get { return "#" + Hymn_Number + " " + Hymn_Name; } }


    }
}