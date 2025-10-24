using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Api.Data;
using MyOnlineShop.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace MyOnlineShop.Api.Repositories
{
    public class DiscountCouponRepository : IDiscountCouponRepository
    {
        private readonly AppDbContext _context;
        public DiscountCouponRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiscountCoupon>> GetAllAsync() => await _context.DiscountCoupons.ToListAsync();

        public async Task<DiscountCoupon?> GetByCodeAsync(string code)
        {
            return await _context.DiscountCoupons.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task AddAsync(DiscountCoupon coupon)
        {
            _context.DiscountCoupons.Add(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var coupon = await GetByCodeAsync(code);
            if(coupon != null)
            {
                _context.DiscountCoupons.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
