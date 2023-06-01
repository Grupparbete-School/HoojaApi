﻿namespace HoojaApi.Models.DTO.ProductReviewDto
{
    public class ProductReviewPutDto
    {
        public int ReviewId { get; set; }
        public int? FK_ProductId { get; set; }
        public string? Review { get; set; }
        public int? Rating { get; set; }
        public string? CustomerName { get; set; }
        public DateTime ReviewOfDate { get; set; }
    }
}
