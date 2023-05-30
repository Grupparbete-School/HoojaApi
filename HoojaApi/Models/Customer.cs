using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoojaApi.Models.RelationTables;

namespace HoojaApi.Models
{
    //public class Customer
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int CustomerId { get; set; }

    //    [Required]
    //    [StringLength(50)]
    //    [DisplayName("Förnamn")]
    //    public string FirstName { get; set; }

    //    [Required]
    //    [StringLength(50)]
    //    [DisplayName("Efternamn")]

    //    public string LastName { get; set; }

    //    [DisplayName("Kund")]
    //    [NotMapped]
    //    public string FullName => $"{FirstName} {LastName}";

    //    [StringLength(15)]
    //    [DisplayName("Telefonnummer")]
    //    public string? PhoneNumber { get; set; }

    //    [StringLength(15)]
    //    [DisplayName("Personnummer")]
    //    public string? SecurityNumber { get; set; }

    //    [Required]
    //    [StringLength(50)]
    //    public string Email { get; set; }

    //    [ForeignKey("Addresses")]
    //    public int FK_AddressId { get; set; }
    //    public virtual Address? Addresses { get; set; }
    //    //public ICollection<Address>? Addresses { get; set; }
    //    //public ICollection<Order>? Orders { get; set; }

    //}
}
