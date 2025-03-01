﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PassportFile { get; set; }
        public int DepartmentId { get; set; }
        public Department.Department Department { get; set; }
        public ICollection<Rent.Rent> Rents { get; set; }
        public ICollection<Product.Product> Products { get; set; }
    }
}
