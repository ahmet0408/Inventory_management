using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.ProductForBarcodeDTO
{
    public class ProductForBarcodeDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Barcode { get; set; }
        public DateTime ArrivalAt { get; set; }
    }
}
