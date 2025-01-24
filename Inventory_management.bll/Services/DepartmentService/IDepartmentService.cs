using Inventory_management.bll.DTOs.DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task CreateDepartment(CreateDepartmentDTO modelDTO);
        Task EditDepartment(EditDepartmentDTO modelDTO);
        Task RemoveDepartment(int id);
        IEnumerable<DepartmentDTO> GetDepartments();
    }
}
