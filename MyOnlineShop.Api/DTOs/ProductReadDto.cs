namespace MyOnlineShop.Api.DTOs
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal PriceAfterProductDiscount { get; set; }
    }
}
