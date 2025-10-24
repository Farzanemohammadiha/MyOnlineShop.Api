namespace MyOnlineShop.Api.DTOs
{
    public class DiscountCouponCreateDto
    {
        public string Code { get; set; } = "";
        public int Percentage { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsActive { get; set; }
    }
}
