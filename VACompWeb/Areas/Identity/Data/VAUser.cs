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
        VetOnly,
        VetSpouse,
        VetSpouse1P,
        VetSpouse2P,
        Vet1P,
        Vet2P,
        Vet1C,
        VetSpouse1C,
        VetSpouse1C1P,
        VetSpouse1C2P,
        Vet1C1P,
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
        [RegularExpression("[1 - 9][0 - 9] * 0")]
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

        //public VAUser User { get; internal set; }
    }
}
