using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models
{
    public class CampaignCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CampaignCodeId { get; set; } = null;

        [StringLength(60)]
        public string? CampaignName { get; set; }

        [Required]
        [DisplayName("Kampanj start")]
        public DateTime CampaignStart { get; set; }
        
        [Required]
        [DisplayName("Kampanj slut")]
        public DateTime CampaignEnd  { get; set; }

        [Required]
        [DisplayName("Procent")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercentage { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
