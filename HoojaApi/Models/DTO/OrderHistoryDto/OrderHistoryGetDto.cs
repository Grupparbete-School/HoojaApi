using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models.DTO.OrderHistoryDto
{
    public class OrderHistoryGetDto
    {
        public int OrderId { get; set; }

        //Order
        [DisplayName("Comment")]
        public string? OrderComment { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        //Produkt
        public int ProductId { get; set; }
        public string? Brand { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? Price {get; set; }
        public int? QuantityStock { get; set; }
        public int? Amount { get; set; }
        public decimal? TotalPrice { get; set; }

        //Produkt grupp
        public int? ProductTypeId { get; set; }
        public string? ProductTypeName { get; set; }

        //Kampanj
        public int? CampaignCodeId { get; set; }
        public string? CampaignName { get; set; }
        //Kund
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecurityNumber { get; set; }
        public string? Email { get; set; }

        //Adress
        public int? AddressId { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }


    }
}
