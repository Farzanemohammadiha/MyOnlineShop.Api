namespace MyOnlineShop.Api.DTOs
{
    public class DiscountCouponReadDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public int Percentage { get; set; } 
        public bool IsActive { get; set; }
        public DateTime Expiry { get; set; }
    }
}
