using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.ProductDTO
{
    public class ProductTranslateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCulture { get; set; }
    }
}
