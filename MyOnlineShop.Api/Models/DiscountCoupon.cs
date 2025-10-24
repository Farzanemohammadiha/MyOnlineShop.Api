namespace MyOnlineShop.Api.Models
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Percentage { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsActive {  get; set; }
    }
}
