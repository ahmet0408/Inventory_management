using Inventory_management.bll.DTOs.CategoryDTO;
using Inventory_management.bll.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(createCategoryDTO);
                return Ok(createCategoryDTO);
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditCategory([FromBody] EditCategoryDTO editCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.EditCategory(editCategoryDTO);
                return Ok(editCategoryDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task RemoveCategory(int id)
        {
            await _categoryService.RemoveCategory(id);
        }
    }
}
