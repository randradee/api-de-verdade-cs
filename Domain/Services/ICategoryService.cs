using api_de_verdade.Domain.Models;

namespace api_de_verdade.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

    }
}
