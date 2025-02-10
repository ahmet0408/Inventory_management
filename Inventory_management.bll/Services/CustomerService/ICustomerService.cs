using Inventory_management.bll.DTOs.CustomeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CustomerService
{
    public interface ICustomerService
    {
        Task CreateCustomer(CreateCustomerDTO modelDTO);
        IEnumerable<CustomerDTO> GetCustomers();
    }
}
