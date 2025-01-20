using Inventory_management.dal.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Barcode { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public DateTime ArrivalAt { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<ProductTranslate> ProductTranslates { get; set; }
    }
}
