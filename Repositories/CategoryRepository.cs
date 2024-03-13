using api_de_verdade.Data.Contexts;
using api_de_verdade.Data.Repositories;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace api_de_verdade.Repositories
{
    public class CategoryRepository(AppDbContext context) : BaseRepository(context), ICategoryRepository
    {
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            return category;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}