using MyOnlineShop.Api.Models;

namespace MyOnlineShop.Api.Repositories
{
    public interface IDiscountCouponRepository
    {
        Task<List<DiscountCoupon>> GetAllAsync();
        Task<DiscountCoupon?> GetByCodeAsync(string code);
        Task AddAsync(DiscountCoupon coupon);
        Task DeleteAsync(string code);
    }
}
