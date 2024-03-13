using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.Dtos.CategoryDtos;
using api_de_verdade.Domain.Services.Communication;

namespace api_de_verdade.Domain.Services
{
    public interface ICategoryService
    {
        Task<Response<IEnumerable<GetCategoryDto>>> ListAsync();
        Task<Response<GetCategoryDto>> FindByIdAsync(int id);
        Task<Response<CreateCategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto);
        Task<Response<UpdateCategoryDto>> UpdateAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task<Response<GetCategoryDto>> DeleteAsync(int id);
    }
}
