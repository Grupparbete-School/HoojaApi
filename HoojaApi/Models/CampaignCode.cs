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

        public string? CampaignName { get; set; }

        [Required]
        [DisplayName("Campaign start")]
        public DateTime CampaignStart { get; set; }
        
        [Required]
        [DisplayName("Campaign end")]
        public DateTime CampaignEnd  { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
