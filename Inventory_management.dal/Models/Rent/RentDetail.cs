using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Rent
{
    public class RentDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
        public int RentId { get; set; }
        public Rent Rent { get; set; }
    }
}
