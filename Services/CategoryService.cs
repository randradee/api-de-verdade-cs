using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using api_de_verdade.Domain.Services;

namespace api_de_verdade.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}
