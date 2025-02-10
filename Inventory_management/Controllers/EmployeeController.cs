using Inventory_management.bll.DTOs.EmployeeDTO;
using Inventory_management.bll.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDTO createEmployeeDTO)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployee(createEmployeeDTO);
                return Ok(createEmployeeDTO);
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditEmployee([FromForm] EditEmployeeDTO editEmployeeDTO)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.EditEmployee(editEmployeeDTO);
                return Ok(editEmployeeDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task RemoveEmployee(int id)
        {
            await _employeeService.RemoveEmployee(id);
        }
    }
}
