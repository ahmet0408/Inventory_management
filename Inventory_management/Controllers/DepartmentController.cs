using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.bll.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
