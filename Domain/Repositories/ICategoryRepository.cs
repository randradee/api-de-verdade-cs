using api_de_verdade.Data.Repositories;
using api_de_verdade.Domain.Models;

namespace api_de_verdade.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
