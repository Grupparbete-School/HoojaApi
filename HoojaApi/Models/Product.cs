using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoojaApi.Models.RelationTables;

namespace HoojaApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(2000, 10)]
        public int ProductId { get; set; }
        public string? Brand { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }

        [Required]
        [DisplayName("Price")]
        [MaxLength(10)]
        public int Price { get; set; }

        [DisplayName("Qty in stock")]
        public int QuantityStock { get; set; }

        //ändrade från byte[] till string.
        [StringLength(300)]
        public string? ProductPicture { get; set; }

        //Relations
        [ForeignKey("ProductTypes")]
        public int FK_ProductTypeId { get; set; }
        public ProductType? ProductTypes { get; set; }

        [ForeignKey("CampaignCodes")]
        public int? FK_CampaignCodeId { get; set; } = null;
        public CampaignCode? CampaignCodes { get; set; }

        public ICollection<ProductReview>? Reviews { get; set; }

    }
}
