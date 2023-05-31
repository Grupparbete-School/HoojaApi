namespace HoojaApi.Models.DTO.CampaignDto
{
    public class CampaignPUTDto
    {
        public int? CampaignCodeId { get; set; }

        public string? CampaignName { get; set; }

        public DateTime? CampaignStart { get; set; }

        public DateTime? CampaignEnd { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public bool? IsActive { get; set; }
    }
}
