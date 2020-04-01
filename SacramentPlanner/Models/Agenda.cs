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
        [Required] 
        public Category Section { get; set; }
        public int MemberID { get; set; }
        public int HymnID { get; set; }
        public string Special_Event_Text { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }

        [ForeignKey("MemberID")]
        public Directory Directory { get; set; }

        [ForeignKey("HymnID")]
        public Hymn Hymn { get; set; }


        public enum Category
        {
            Speaker,
            Special_Event,
            Hymn,
            Special_Musical_Number
        }
    }
}
