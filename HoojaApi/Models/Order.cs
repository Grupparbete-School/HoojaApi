 using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Comment")]
        public string? OrderComment { get; set; } = null;

        [Required]
        [DisplayName("Order datum")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [DisplayName("Beräknat leveransdatum")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(5);

        [DisplayName("Antal")]
        public int? Amount { get; set; }

        [ForeignKey("Customers")]
        public int FK_CustomerId { get; set; }
        public Customer? Customers { get; set; }
    }
}
