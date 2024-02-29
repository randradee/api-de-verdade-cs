using api_de_verdade.Domain.Models;
using api_de_verdade.Domain.Services;
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
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryService.ListAsync();
        }
    }
}
