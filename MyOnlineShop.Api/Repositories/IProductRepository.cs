using System.Collections.Generic;
using System.Threading.Tasks;
using MyOnlineShop.Api.Models;

namespace MyOnlineShop.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id); 
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);        
    }
}
