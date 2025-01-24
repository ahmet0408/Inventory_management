using Inventory_management.bll.DTOs.ProductDTO;
using Inventory_management.bll.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO createProductDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateProduct(createProductDTO);
                return Ok(createProductDTO);
            }
            return BadRequest();
        }
    }
}
