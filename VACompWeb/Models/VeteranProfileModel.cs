using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VACompWeb.Models
{

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
    public class VeteranProfileModel : IdentityUser
    {
        [Required]
        public int VetID { get; set; }



        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FirstName { get; set; }



        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string LastName { get; set; }


        [Required]
        [Range(10,100)]
        [RegularExpression("[1 - 9][0 - 9] * 0")]
        public int DisabilityRating { get; set; }



        [Required]
        public DepStatus DependencyStatus { get; set; }



        [Required]
        public int AddChileUnder18 { get; set; }



        [Required]
        public int AddChild18Plus { get; set; }


        [Required]
        public bool AidSupport { get; set; }



    }
}
