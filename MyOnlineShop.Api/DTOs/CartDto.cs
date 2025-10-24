namespace MyOnlineShop.Api.DTOs
{
    public class CartDto
    {
        public List<CartItemDto> Items { get; set; }
        public string CouponCode { get; set; }
    }
}
