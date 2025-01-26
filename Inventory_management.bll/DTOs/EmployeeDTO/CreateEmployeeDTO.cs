using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.EmployeeDTO
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
        public string Job { get; set; }
        public IFormFile FormPicture { get; set; }
        public string PassportFile { get; set; }
        public int DepartmentId { get; set; }
    }
}
