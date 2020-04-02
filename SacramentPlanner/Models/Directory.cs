using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Directory
    {
        public int DirectoryID { get; set; }

        public int WardID { get; set; }
        [ForeignKey("WardID")]
        public Ward Ward { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Sex { get; set; }


        public Title? Calling { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }
    public enum Title
    {
        [Display(Name = "Stake President")]
        StakePresident,
        Bishop,
        [Display(Name = "Stake First Councellor")]
        StakeFirstCouncellor,
        [Display(Name = "Stake Second Councellor")]
        StakeSecondCouncellor,
        [Display(Name = "Ward First Councellor")]
        WardFirstCouncellor,
        [Display(Name = "Ward Second Councellor")]
        WardSecondCouncellor
    }
}
