using Inventory_management.dal.Models.Rent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.RentDTO
{
    public class RentDTO
    {
        public int RentNumber { get; set; }
        public RentStatus RentStatus { get; set; }
        public DateTime DateOfShipment { get; set; } = DateTime.Now;
        public DateTime DateOfReturn { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPicture { get; set; }
        public string Mark { get; set; }
        public string UserId { get; set; }
        public string ResponsibleEmployee { get; set; }
        public ICollection<RentDetailDTO> RentDetails { get; set; } 
    }
}
