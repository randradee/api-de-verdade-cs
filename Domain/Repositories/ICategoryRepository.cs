using api_de_verdade.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_de_verdade.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category> GetAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(int id, Category category);
        Task DeleteAsync(int id);
    }
}
