using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Api.DTOs;
using MyOnlineShop.Api.Models;
using MyOnlineShop.Api.Repositories;

namespace MyOnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET api/products
        [HttpGet]
        public async Task<ActionResult<List<ProductReadDto>>> GetAll()
        {
            var products = await _repo.GetAllAsync();

            var dtos = products.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPercent = p.DiscountPercent,
                PriceAfterProductDiscount = p.GetPriceAfterProductDiscount()
            }).ToList();

            return Ok(dtos);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> Get(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null)
                return NotFound();

            var dto = new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPercent = p.DiscountPercent,
                PriceAfterProductDiscount = p.GetPriceAfterProductDiscount()
            };

            return Ok(dto);
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Create([FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var p = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,               
                DiscountPercent = dto.DiscountPercent,
            };

            await _repo.AddAsync(p);

            var result = new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DiscountPercent = p.DiscountPercent,
                PriceAfterProductDiscount = p.GetPriceAfterProductDiscount()
            };

            return CreatedAtAction(nameof(Get), new { id = p.Id }, result);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var p = await _repo.GetByIdAsync(id);
            if (p == null)
                return NotFound();

            p.Name = dto.Name;
            p.Description = dto.Description;
            p.Price = dto.Price;                 
            p.DiscountPercent = dto.DiscountPercent;

            await _repo.UpdateAsync(p);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var deleteResult = await _repo.DeleteAsync(id);
            if (deleteResult is bool)
            {
                if ((bool)deleteResult) return NoContent();
                return NotFound();
            }

            
            return NoContent();
        }
    }
}
