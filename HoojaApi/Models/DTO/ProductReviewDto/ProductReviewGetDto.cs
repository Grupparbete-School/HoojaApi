using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HoojaApi.Models.DTO.ProductReviewDto
{
    public class ProductReviewGetDto
    {
        public int ReviewId { get; set; }
        public int? FK_ProductId { get; set; }
        public string? Review { get; set; }
        public int? Rating { get; set; }
        public string? ProductName { get; set; }
        public string? CustomerName { get; set; }
        public DateTime ReviewOfDate { get; set; }
    }
}
