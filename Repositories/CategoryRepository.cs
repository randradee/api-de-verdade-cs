using api_de_verdade.Data.Contexts;
using api_de_verdade.Data.Repositories;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace api_de_verdade.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

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

        public async Task DeleteAsync(int id)
        {
            var categoryToDelete = await _context.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == id) ?? throw new Exception("Categoria a ser excluída não existe");


            _context.Categories.Remove(categoryToDelete);

            await _context.SaveChangesAsync();
        }

        public void DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}