using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.DTOs;
using api_de_verdade.Domain.Services;
using api_de_verdade.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace api_de_verdade.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetCategoryDto>> GetCategoriesAsync()
        {
            return await _categoryService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetCategoryDto> GetCategoryById(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var result = await _categoryService.CreateAsync(createCategoryDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Created(result.Message, result.Resource);
        }

    }
}
