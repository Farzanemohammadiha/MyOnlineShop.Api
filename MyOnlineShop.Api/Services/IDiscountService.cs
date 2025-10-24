using System.Threading.Tasks;
using MyOnlineShop.Api.Models;

namespace MyOnlineShop.Api.Services
{
    public interface IDiscountService
    {
        Task<DiscountCoupon> GetActiveCouponByCodeAsync(string code);
        decimal ApplyCoupon(decimal subtotal, DiscountCoupon coupon);

    }
}
