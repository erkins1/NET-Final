using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentPlanner.Models
{
    public class Agenda
    {
        public int AgendaID { get; set; }
        public Category Section { get; set; }
        public int Member { get; set; }
        public int Hymn { get; set; }
        public string Special_Event_Text { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }

        [ForeignKey("Member")]
        public Directory Directory { get; set; }

        [ForeignKey("Hymn")]
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
