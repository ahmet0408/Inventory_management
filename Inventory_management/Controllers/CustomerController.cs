using Inventory_management.bll.DTOs.CustomeDTO;
using Inventory_management.bll.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromForm] CreateCustomerDTO createCustomerDTO)
        {
            if (ModelState.IsValid)
            {
                await _customerService.CreateCustomer(createCustomerDTO);
                return Ok(createCustomerDTO);
            }
            return BadRequest();
        }
    }
}
