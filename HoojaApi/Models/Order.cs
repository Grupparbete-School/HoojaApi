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
        [DisplayName("Order date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [DisplayName("Expected delivery")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(5);

        [ForeignKey("Users")]
        public int FK_CustomerId { get; set; }
        public User? Users { get; set; }
    }
}
