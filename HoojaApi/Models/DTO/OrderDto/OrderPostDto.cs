using System.ComponentModel.DataAnnotations;

namespace HoojaApi.Models.DTO.OrderDto
{
    public class OrderPostDto
    {
        [Required]
        public int? ProductId { get; set; }

        public string OrderComment { get; set; } = "no comment";

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        public int? userId { get; set; }
    }
}
