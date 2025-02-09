using Inventory_management.bll.DTOs.ProductDTO;
using Inventory_management.bll.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
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

        [HttpPost("getbybarcode")]
        public async Task<IActionResult> GetProductByBarcode([FromBody] string barcodeText)
        {
            if (string.IsNullOrEmpty(barcodeText))
            {
                return BadRequest(new { message = "nädogry maglumat" });
            }
            var product = await _productService.GetProductByBarcode(barcodeText);
            if (product != null) { return Ok(product); }
            return BadRequest();
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
