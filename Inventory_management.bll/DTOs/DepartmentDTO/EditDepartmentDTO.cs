using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.DepartmentDTO
{
    public class EditDepartmentDTO
    {
        public int Id { get; set; }
        public ICollection<DepartmentTranslateDTO> DepartmentTranslates { get; set; }
    }
}
