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

        [Required]
        [Display(Name = "Ward")]
        public int WardID { get; set; }
        [Required]
        public int Presiding { get; set; }
        [Required] 
        public int Conducting { get; set; }
        [Required]
        [Display(Name = "Opening Hymn")]
        public int Opening_Hymn { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "By Invitation")]
        public int? Invocation { get; set; }
        [Display(Name = "Ward Business")]
        public bool Ward_Business { get; set; }
        public bool Sacrament { get; set; }
        [Required]
        [Display(Name = "Sacrament Hymn")]
        public int Sacrament_Hymn { get; set; }
        [Required]
        [Display(Name = "Closing Hymn")]
        public int Closing_Hymn { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "By Invitation")]
        public int? Benediction { get; set; }


        [ForeignKey("WardID")]
        public Ward Ward { get; set; }

        [ForeignKey("Presiding")]
        [Display(Name = "Presiding")]
        public Directory PresidingDirectory { get; set; }

        [ForeignKey("Conducting")]
        [Display(Name = "Conducting")]
        public Directory ConductingDirectory { get; set; }

        [ForeignKey("Opening_Hymn")]
        [Display(Name = "Opening Hymn")]
        public Hymn Opening_HymnHymn { get; set; }

        [ForeignKey("Invocation")]
        [Display(Name = "Invocation")]
        public Directory InvocationDirectory { get; set; }

        [ForeignKey("Sacrament_Hymn")]
        [Display(Name = "Sacrament Hymn")]
        public Hymn Sacrament_HymnHymn { get; set; }

        [ForeignKey("Closing_Hymn")]
        [Display(Name = "Closing Hymn")]
        public Hymn Closing_HymnHymn { get; set; }

        [ForeignKey("Benediction")]
        [Display(Name = "Invocation")]
        public Directory BenedictionDirectory { get; set; }



    }
}
