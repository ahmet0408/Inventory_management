using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;

namespace Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _imageStoragePath;
        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            // Combines the web root path with a specific images folder
            _imageStoragePath = Path.Combine(
                environment.WebRootPath,
                "images"
            );

            // Ensures the directory exists
            Directory.CreateDirectory(_imageStoragePath);
        }

        [HttpGet("{foldername}/{filename}")]
        public IActionResult GetImage(string foldername, string filename)
        {
            var path = Path.Combine(_imageStoragePath, foldername, filename);
            if (!System.IO.File.Exists(path))
                return NotFound();

            // Determine content type
            var contentType = GetContentType(filename);

            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, contentType); // Adjust MIME type as needed
        }

        // Helper method to determine MIME type
        private string GetContentType(string filename)
        {
            var ext = Path.GetExtension(filename).ToLowerInvariant();
            return ext switch
            {
                ".png" => "image/png",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
        }
    }
}
