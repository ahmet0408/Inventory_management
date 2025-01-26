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
        [HttpGet]
        public IActionResult GetProducts() 
        { 
            var products = _productService.GetProducts();
            return Ok(products);    
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

        [HttpPut("edit")]
        public async Task<IActionResult> EditProduct([FromForm] EditProductDTO editProductDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.EditProduct(editProductDTO);
                return Ok(editProductDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task RemoveProduct(int id)
        {
            await _productService.RemoveProduct(id);
        }
    }
}
