using Inventory_management.dal.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }        
        public Employee.Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ApplicationUser  User { get; set; }
        public string UserId { get; set; }
        public int CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
