using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.EmployeeDTO
{
    public class EditEmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Picture { get; set; }
        public IFormFile FormPicture { get; set; }
        public string PassportFile { get; set; }
        public int DepartmentId { get; set; }
    }
}
