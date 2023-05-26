namespace HoojaApi.Models.DTO.ProductDto
{
    public class AddProductDto
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int Price { get; set; }

        public int QuantityStock { get; set; }

        public string? ProductPicture { get; set; }

        public int FK_ProductTypeId { get; set; }
    }
}
