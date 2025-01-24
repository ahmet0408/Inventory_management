using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.ProductDTO
{
    public class ProductTranslateDTO
    {
        [FromForm]
        public int Id { get; set; }
        [FromForm]
        public string Name { get; set; }
        [FromForm]
        public string Description { get; set; }
        [FromForm]
        public string LanguageCulture { get; set; }
    }
}
