using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MyOnlineShop.Api.DTOs;
using MyOnlineShop.Api.Models;
using MyOnlineShop.Api.Repositories;


namespace MyOnlineShop.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountCouponRepository _repo;


        public DiscountCouponsController(IDiscountCouponRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiscountCouponReadDto>>> GetAll()
        {
            var coupons = await _repo.GetAllAsync();
            var dtos = coupons.Select(c => new DiscountCouponReadDto
            {
                Id = c.Id,  
                Code = c.Code,
                Percentage = c.Percentage,
                Expiry = c.Expiry,
                IsActive = c.IsActive
            }).ToList();

            return Ok(dtos);
        }


        [HttpPost]

        public async Task<ActionResult<DiscountCouponReadDto>> Create(DiscountCouponCreateDto dto)
        {
            var coupon = new DiscountCoupon
            {
                Code = dto.Code,
                Percentage = dto.Percentage,
                Expiry = dto.Expiry,
                IsActive = dto.IsActive

            };

            await _repo.AddAsync(coupon);

            var result = new DiscountCouponReadDto
            {
                Id = coupon.Id,
                Code = coupon.Code,
                Percentage = coupon.Percentage,
                Expiry = coupon.Expiry,
                IsActive = coupon.IsActive
            };

            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}
