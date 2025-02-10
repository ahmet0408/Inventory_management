using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.bll.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO createDepartmentDTO)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.CreateDepartment(createDepartmentDTO);
                return Ok(createDepartmentDTO);
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditDepartment([FromBody] EditDepartmentDTO editDepartmentDTO)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.EditDepartment(editDepartmentDTO);
                return Ok(editDepartmentDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task RemoveDepartment(int id)
        {
            await _departmentService.RemoveDepartment(id);
        }
    }
}
