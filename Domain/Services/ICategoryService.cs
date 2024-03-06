using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.DTOs;
using api_de_verdade.Domain.Services.Communication;

namespace api_de_verdade.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> ListAsync();
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task<Response<CreateCategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto);
    }
}
