namespace HoojaApi.Models.DTO.CampaignDto
{
	public class CampaignCodeDto
	{
		public string? CampaignName { get; set; }

		public DateTime? CampaignStart { get; set; }

		public DateTime? CampaignEnd { get; set; }

		public decimal DiscountPercentage { get; set; }
	}
}
