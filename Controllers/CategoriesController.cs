using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.Dtos.CategoryDtos;
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
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _categoryService.ListAsync();

            return Ok(result.Resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _categoryService.FindByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _categoryService.CreateAsync(createCategoryDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Created(result.Message, result.Resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryById(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _categoryService.UpdateAsync(id, updateCategoryDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
