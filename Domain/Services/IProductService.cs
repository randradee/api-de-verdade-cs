using api_de_verdade.Domain.Dtos.ProductDtos;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Services.Communication;

namespace api_de_verdade.Domain.Services
{
    public interface IProductService
    {
        Task<Response<IEnumerable<GetProductDto>>> GetProductsAsync();
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto product);


    }
}
