using api_de_verdade.Data.Contexts;
using api_de_verdade.Data.Repositories;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();

            return category;
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var categoryToUpdate = await _context.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == id);

            if (categoryToUpdate == null || category == null)
            {
                throw new InvalidOperationException("category doesn't exist");
            }

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Products = category.Products;

            await _context.Categories.AddAsync(categoryToUpdate);
            _context.SaveChanges();

            return categoryToUpdate;
        }

        public async Task DeleteAsync(int id)
        {
            var categoryToDelete = await _context.Categories
                .AsNoTracking()
                .FirstAsync(c => c.Id == id) ?? throw new Exception("Categoria a ser excluída não existe");


            _context.Categories.Remove(categoryToDelete);

            await _context.SaveChangesAsync();
        }
    }
}