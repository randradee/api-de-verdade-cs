using api_de_verdade.Domain.Models;

namespace api_de_verdade.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> CreateAsync(Product product);
    }
}
