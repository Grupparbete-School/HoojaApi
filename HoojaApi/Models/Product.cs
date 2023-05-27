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

        [Required]
        [StringLength(50)]
        [DisplayName("Produkt")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        [DisplayName("Beskrivning")]
        public string ProductDescription { get; set; }

        [Required]
        [DisplayName("Pris")]
        public int Price { get; set; }

        [DisplayName("Antal i lager")]
        public int QuantityStock { get; set; }

        //ändrade från byte[] till string.
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
