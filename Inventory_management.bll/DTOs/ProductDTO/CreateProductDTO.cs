using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public string Status { get; set; }
        public IFormFile FormImage { get; set; }
        public DateTime ArrivalAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

    }
}
