using Inventory_management.bll.DTOs.RentDTO;
using Inventory_management.bll.Services.RentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public IActionResult GetAllRent()
        {
            var rents = _rentService.GetAllRent();
            return Ok(rents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRent(RentDTO rentDTO)
        {
            if (ModelState.IsValid)
            {
                await _rentService.CreateRent(rentDTO);
                return Ok(rentDTO);
            }
            return BadRequest();
        }
    }
}
