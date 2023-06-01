using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models.RelationTables
{
    public class ProductReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductReviewId { get; set; }

        [DisplayName("Review")]
        [StringLength(300)]
        public string? Review { get; set; }

        [ForeignKey("Products")]
        public int? FK_ProductId { get; set; } = null;
        public Product? Products { get; set; }
    }
}