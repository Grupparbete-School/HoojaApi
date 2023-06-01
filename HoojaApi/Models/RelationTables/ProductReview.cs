using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoojaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

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

        [Range(0, 5)]
        public int? Rating { get; set; }

        [DisplayName("Customer")]
        [StringLength(50)]
        public string? CustomerName { get; set; }

        [Required]
        [DisplayName("Review Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime ReviewOfDate { get; set; } = DateTime.Now.Date;

        [ForeignKey("Products")]
        public int? FK_ProductId { get; set; } = null;
        public Product? Products { get; set; }
    }
}