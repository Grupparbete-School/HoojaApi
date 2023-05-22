using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models.RelationTables
{
    public class OrderHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderProductId { get; set; }

        [ForeignKey("Orders")]
        public int FK_OrderId { get; set; }
        public Order? Orders { get; set; }

        [ForeignKey("Products")]
        public int FK_ProductId { get; set; }
        public Product? Products { get; set; }

        [DisplayName("Antal köpta varor")]
        public int Amount { get; set; }
    }
}
