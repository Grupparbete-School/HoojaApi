using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models.RelationTables
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Gata")]
        public string? Street { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Postnummer")]
        public string? PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Stad")]
        public string City { get; set; }

        //[ForeignKey("Customers")]
        //public int? FK_CustomerId { get; set; } = null;
        //public Customer? Customers { get; set; }

        //[ForeignKey("Employees")]
        //public int? FK_EmployeeId { get; set; } = null;
        //public Employee? Employees { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        //public virtual ICollection<Customer>? Customers { get; set; }
    }
}