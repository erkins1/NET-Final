using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Agenda
    {
        public int AgendaID { get; set; }
        public int MeetingID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public Category Section { get; set; }
        [Display(Name = "Member")]
        public int? MemberID { get; set; }
        [Display(Name = "Hymn")]
        public int? HymnID { get; set; }
        [Display(Name = "Special Event")]
        public string Special_Event_Text { get; set; }
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [ForeignKey("MemberID")]
        [Display(Name = "Member")]
        public Directory Directory { get; set; }

        [ForeignKey("HymnID")]
        public Hymn Hymn { get; set; }

        [ForeignKey("MeetingID")]
        public Meeting Meeting { get; set; }


        
    }
    public enum Category
    {
        Speaker,
        [Display(Name = "Special Event")]
        Special_Event,
        Hymn,
        [Display(Name = "Special Musical Number")]
        Special_Musical_Number,
        [Display(Name = "Testimony Meeting")]
        Testimony_Meeting
    }
}
