using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using Inventory_management.bll.Services.CompanyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDTO createCompanyDTO)
        {
            if (ModelState.IsValid)
            {
                await _companyService.CreateCompany(createCompanyDTO);
                return Ok(createCompanyDTO);
            }
            return BadRequest();
        }

        [HttpPut("edit")] //{id} optional
        public async Task<IActionResult> EditCompany([FromForm] EditCompanyDTO editCompanyDTO)
        {
            if (ModelState.IsValid)
            {
                await _companyService.EditCompany(editCompanyDTO);
                return Ok(editCompanyDTO);
            }
            return BadRequest();
        }
    }
}
