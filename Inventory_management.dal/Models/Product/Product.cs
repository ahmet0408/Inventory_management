﻿using Inventory_management.dal.Models.Rent;
using System;
using System.Collections.Generic;

namespace Inventory_management.dal.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Document { get; set; }
        public DateTime DueDate { get; set; }
        public string Barcode { get; set; }
        public int Order { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime ArrivalAt { get; set; }
        public int CategoryId { get; set; }
        public Category.Category Category { get; set; }
        public int DepartmentId { get; set; }
        public Department.Department Department { get; set; }
        public int EmployeeId { get; set; }
        public Employee.Employee Employee { get; set; }
        public ICollection<ProductTranslate> ProductTranslates { get; set; }
        public ICollection<RentDetail> RentDetails { get; set; }
    }
}
