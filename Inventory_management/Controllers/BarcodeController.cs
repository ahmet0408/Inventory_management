using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Inventory_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcodeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] BarcodeData barcodeData)
        {
            if (string.IsNullOrWhiteSpace(barcodeData.Barcode))
            {
                return BadRequest("Bar-kod boş.");
            }

            Console.WriteLine($"Gelen bar-kod: {barcodeData.Barcode}");
            // Maglumatlary saklamak ýa-da işlemek
            return Ok(new { Success = true, Message = "Bar-kod kabul edildi." });
        }
    }

    public class BarcodeData
    {
        public string Barcode { get; set; }
    }
}
