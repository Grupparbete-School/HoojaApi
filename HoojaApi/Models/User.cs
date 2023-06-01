using HoojaApi.Models.RelationTables;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace HoojaApi.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Employee")]
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        [StringLength(15)]
        [DisplayName("Security number")]
        public string SecurityNumber { get; set; }
        [ForeignKey("Addresses")]
        public int FK_AddressId { get; set; }
        public virtual Address? Addresses { get; set; }

    }
}
