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


        public async Task<Response<IEnumerable<GetCategoryDto>>> ListAsync()
        {
            var categories = await _categoryRepository.ListAsync();
            var categoriesDto = _mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryDto>>(categories);


            return new Response<IEnumerable<GetCategoryDto>>(categoriesDto);
        }

        public async Task<Response<GetCategoryDto>> FindByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(id);
                var categoryDto = _mapper.Map<Category, GetCategoryDto>(category);

                return new Response<GetCategoryDto>(categoryDto);
            }
            catch (Exception ex)
            {
                return new Response<GetCategoryDto>($"erro: {ex.Message}");
            }

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
            catch (Exception ex)
            {
                return new Response<CreateCategoryDto>($"erro: {ex.Message}");
            }
        }

        public async Task<Response<UpdateCategoryDto>> UpdateAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var newCategory = _mapper.Map<UpdateCategoryDto, Category>(updateCategoryDto);

            var categoryToUpdate = await _categoryRepository.FindByIdAsync(id);

            if (categoryToUpdate == null)
                return new Response<UpdateCategoryDto>("Categoria não encontrada");

            try
            {
                categoryToUpdate.Name = newCategory.Name;

                _categoryRepository.Update(categoryToUpdate);
                await _unitOfWork.CompleteAsync();

                var responseCategoryDto = _mapper.Map<Category, UpdateCategoryDto>(categoryToUpdate);

                return new Response<UpdateCategoryDto>(responseCategoryDto);
            }
            catch (Exception ex)
            {
                return new Response<UpdateCategoryDto>($"erro: {ex.Message}");
            }

        }
    }
}
