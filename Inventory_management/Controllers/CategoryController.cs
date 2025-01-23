using Inventory_management.bll.DTOs.CategoryDTO;
using Inventory_management.bll.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(createCategoryDTO);
                return Ok(createCategoryDTO);
            }
            return BadRequest();
        }
    }
}
