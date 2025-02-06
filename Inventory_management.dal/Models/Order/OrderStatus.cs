using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Order
{
    public enum OrderStatus
    {
        Processing,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}
