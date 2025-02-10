using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.CustomeDTO
{
    public class CreateCustomerDTO
    {
        public IFormFile FormPicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string[] Phone { get; set; }
    }
}
