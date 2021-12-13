using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VACompWeb.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the VAUser class
    public enum DepStatus
    {
        [Display(Name = "Veteran Only")]
        VetOnly,
        [Display(Name = "With Spouse(No children or parents)")]
        VetSpouse,
        [Display(Name = "With Spouse and 1 Parent (No children)")]
        VetSpouse1P,
        [Display(Name = "With Spouse and 2 Parents(No children)")]
        VetSpouse2P,
        [Display(Name = "With 1 Parent(No children or spouse)")]
        Vet1P,
        [Display(Name = "With 2 Parents(No children or spouse)")]
        Vet2P,
        [Display(Name = "With 1 Child(No spouse or parents)")]
        Vet1C,
        [Display(Name = "With Spouse and 1 Child(No parents)")]
        VetSpouse1C,
        [Display(Name = "With Spouse and 1 Parent and 1 Child")]
        VetSpouse1C1P,
        [Display(Name = "With Spouse and 2 Parents and 1 Child")]
        VetSpouse1C2P,
        [Display(Name = "With 1 Parent and 1 Child(No spouse)")]
        Vet1C1P,
        [Display(Name = "With 2 Parent and 1 Child(No spouse)")]
        Vet1C2P

    }

    // Add profile data for application users by adding properties to the VACompUser class
    public class VAUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "int")]
        public int VetID { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FirstName { get; set; }


        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        [Range(10, 100)]
        //[RegularExpression("[1 - 9][0 - 9] * 0")]
        public int DisabilityRating { get; set; }


        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public DepStatus DependencyStatus { get; set; }


        [PersonalData]
        [Required]
        public int AddChildUnder18 { get; set; }


        [PersonalData]
        [Required]
        public int AddChild18Plus { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "bit")]
        public bool AidSupport { get; set; }


        [PersonalData]
        [Column(TypeName = "decimal")]
        public float MonthlyComp { get; set; }
       


        //public VAUser User { get; internal set; }
    }
}
