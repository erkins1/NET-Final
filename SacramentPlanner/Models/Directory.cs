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

        [Display(Name = "Ward")]
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


        [NotMapped]
        public string Full_Name { get { return Last_Name + ", " + First_Name; } }

        [NotMapped]
        public string Title_Name { get {
                string casualTitle;
                if (Calling.ToString() != "")
                {
                    switch (Calling)
                    {
                        case Title.StakePresident:
                            casualTitle = "Stake President";
                            break;
                        case Title.Bishop:
                            casualTitle = "Bishop";
                            break;
                        case Title.StakeFirstCouncellor:
                            casualTitle = "Stake First Councellor";
                            break;
                        case Title.StakeSecondCouncellor:
                            casualTitle = "Stake Second Councellor";
                            break;
                        case Title.WardFirstCouncellor:
                            casualTitle = "Ward First Councellor";
                            break;
                        case Title.WardSecondCouncellor:
                            casualTitle = "Ward Second Councellor";
                            break;
                        default:
                            casualTitle = "";
                            break;
                    }
                }
                else if (Sex.ToString() == "Male")
                {
                    casualTitle = "Brother";
                }
                else
                {
                    casualTitle = "Sister";
                }
                return casualTitle + " " + First_Name + " " + Last_Name;
                } 
        }

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
