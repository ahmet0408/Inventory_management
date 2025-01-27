using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.CreateCompanyDTO
{
    public class CreateCompanyDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile FormLogo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsPublish { get; set; }
    }
}
