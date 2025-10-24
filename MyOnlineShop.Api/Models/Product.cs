namespace MyOnlineShop.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



        public decimal GetPriceAfterProductDiscount()
        {
            if(DiscountPercent.HasValue && DiscountPercent.Value > 0)
            {
               return Math.Round(Price * (100 - DiscountPercent.Value) / 100M, 2);
            }
            return Price;
        }
    }
}
