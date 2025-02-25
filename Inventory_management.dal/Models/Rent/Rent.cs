using Inventory_management.dal.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Rent
{
    public class Rent
    {
        public int Id { get; set; }
        public RentStatus Status { get; set; }
        public string RentType { get; set; }
        public DateTime DateOfShipment { get; set; }
        public DateTime DateOfReturn { get; set; }        
        public ApplicationUser  User { get; set; }
        public string UserId { get; set; }
        public int CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        public ICollection<RentDetail> RentDetails { get; set; }
    }
}
