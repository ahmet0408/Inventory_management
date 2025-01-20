using System.Collections.Generic;

namespace Inventory_management.dal.Models.Product
{
    public class Department
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<DepartmentTranslate> DepartmentTranslates { get; set; }
    }
}
