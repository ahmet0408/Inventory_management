using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.ProductDTO
{
    public class CreateProductDTO
    {
        public ICollection<ProductTranslateDTO> ProductTranslates { get; set; }
        public int Amount { get; set; }
        public string Barcode { get; set; }
        public int Price { get; set; }
        public DateTime ArrivalAt { get; set; } = DateTime.Now;
    }
}
