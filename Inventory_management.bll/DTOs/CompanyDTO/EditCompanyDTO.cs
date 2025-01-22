using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.CompanyDTO
{
    public class EditCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Logo { get; set; }
        public IFormFile FormLogo { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
