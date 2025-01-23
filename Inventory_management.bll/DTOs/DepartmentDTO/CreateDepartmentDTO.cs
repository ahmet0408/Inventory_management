using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.DepartmentDTO
{
    public class CreateDepartmentDTO
    {
         public ICollection<DepartmentTranslateDTO> DepartmentTranslates { get; set; }
    }
}
