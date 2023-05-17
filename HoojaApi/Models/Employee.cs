using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoojaApi.Models.RelationTables;

namespace HoojaApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Efternamn")]
       
        public string LastName { get; set; }

        [DisplayName("Anställd")]
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(15)]
        [DisplayName("Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Personnummer")]
        public string SecurityNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        //navigering
        public ICollection<Address>? Addresses { get; set; }
    }
}
