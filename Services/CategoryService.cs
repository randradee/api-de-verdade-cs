using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.DTOs;
using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Repositories;
using api_de_verdade.Domain.Services;
using api_de_verdade.Domain.Services.Communication;
using AutoMapper;

namespace api_de_verdade.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<GetCategoryDto>> ListAsync()
        {
            var categories = await _categoryRepository.ListAsync();
            var categoriesDto = _mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryDto>>(categories);

            return categoriesDto;
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            var categoryDto = _mapper.Map<Category, GetCategoryDto>(category);

            return categoryDto;
        }

        public async Task<Response<CreateCategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var categoryToCreate = _mapper.Map<CreateCategoryDto, Category>(createCategoryDto);

            try
            {
                var result = await _categoryRepository.CreateAsync(categoryToCreate);
                await _unitOfWork.CompleteAsync();

                var responseCategoryDto = _mapper.Map<Category, CreateCategoryDto>(result);

                return new Response<CreateCategoryDto>(responseCategoryDto);
            }
            catch(Exception e)
            {
                return new Response<CreateCategoryDto>($"erro: {e.Message}");
            }
        }
    }
}
