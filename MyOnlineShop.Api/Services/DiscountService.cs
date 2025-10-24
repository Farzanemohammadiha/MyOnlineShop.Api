using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Api.Data;
using MyOnlineShop.Api.Models;

namespace MyOnlineShop.Api.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly AppDbContext _context;


        public DiscountService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<DiscountCoupon> GetActiveCouponByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return null;
            var c = await _context.DiscountCoupons.FirstOrDefaultAsync(x => x.Code == code);
            if (c == null) return null;
            if (!c.IsActive) return null;
            if (c.Expiry < DateTime.UtcNow) return null;
            return c;
        }

        public decimal ApplyCoupon(decimal subtotal, DiscountCoupon coupon)
        {
            if (coupon == null) return 0M;
            return Math.Round(subtotal * coupon.Percentage / 100M, 2);  
        }
    }
}
