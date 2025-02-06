﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Order
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
