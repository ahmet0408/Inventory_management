using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.RentDTO
{
    public class RentDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
