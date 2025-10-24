namespace MyOnlineShop.Api.DTOs
{
    public class CartTotalDto
    {
        public decimal Subtotal { get; set; }
        public decimal ProductLevelDiscount { get; set; }
        public decimal CouponDiscount { get; set; }
        public decimal Total { get; set; }

        public List<string> Lines { get; set; } = new List<string>();

    }
}
