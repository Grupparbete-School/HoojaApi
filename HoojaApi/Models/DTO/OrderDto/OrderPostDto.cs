namespace HoojaApi.Models.DTO.OrderDto
{
    public class OrderPostDto
    {
        public int? ProductId { get; set; }
        public int? Amount { get; set; }

        public string? OrderComment { get; set; } = "no comment";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
