namespace HoojaApi.Models.DTO.ProductDto
{
    public class ProductPUTDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int Price { get; set; }

        public int QuantityStock { get; set; }

        public string? ProductPicture { get; set; }

        public int ProductTypeId { get; set; }
    }
}
