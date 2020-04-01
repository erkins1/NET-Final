using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int WardID { get; set; }
        public int Presiding { get; set; }
        public int Conducting { get; set; }
        public int Opening_Hymn { get; set; }
        public int Invocation { get; set; }
        public bool Ward_Business { get; set; }
        public bool Sacrament { get; set; }
        public int Sacrament_Hymn { get; set; }
        public int Closing_Hymn { get; set; }
        public int Benediction { get; set; }


        [Required, ForeignKey("WardID")]
        public Ward Ward { get; set; }

        [Required, ForeignKey("Presiding")]
        public Directory Directory { get; set; }

        [Required, ForeignKey("Conducting")]
        public Directory Directory { get; set; }

        [Required, ForeignKey("Opening_Hymn")]
        public Hymn Hymn { get; set; }

        [ForeignKey("Invocation")]
        public Directory Directory { get; set; }

        [ForeignKey("Sacrament_Hymn")]
        public Hymn Hymn { get; set; }

        [Required, ForeignKey("Closing_Hymn")]
        public Hymn Hymn { get; set; }

        [ForeignKey("Benediction")]
        public Directory Directory { get; set; }



    }
}
