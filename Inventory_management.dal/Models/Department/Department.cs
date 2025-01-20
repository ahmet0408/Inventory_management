using System.Collections.Generic;

namespace Inventory_management.dal.Models.Department
{
    public class Department
    {
        public int Id { get; set; }
        public ICollection<Product.Product> Products { get; set; }
        public ICollection<Employee.Employee> Employees { get; set; }
        public ICollection<DepartmentTranslate> DepartmentTranslates { get; set; }
    }
}
