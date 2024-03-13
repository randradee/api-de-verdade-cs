using api_de_verdade.Domain.Dtos.ProductDtos;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Services.Communication;

namespace api_de_verdade.Domain.Services
{
    public interface IProductService
    {
        Task<Response<IEnumerable<GetProductDto>>> GetProductsAsync();
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto product);
        Task<Response<GetProductDto>> FindByIdAsync(int id);
        Task<Response<UpdateProductDto>> UpdateProduct(int id, UpdateProductDto product);
        Task<Response<GetProductDto>> DeleteProduct(int id);
    }
}
