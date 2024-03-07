using api_de_verdade.Domain.Models;

namespace api_de_verdade.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category?> FindByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        void Update(Category category);
        Task DeleteAsync(int id);
    }
}
