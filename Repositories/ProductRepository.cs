using api_de_verdade.Data.Contexts;
using api_de_verdade.Data.Repositories;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_de_verdade.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) 
        {
        
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.AddAsync(product);

            return product;
        }
    }
}
