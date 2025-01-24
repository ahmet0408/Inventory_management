using Inventory_management.bll.DTOs.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task CreateEmployee(CreateEmployeeDTO modelDTO);
        Task EditEmployee(EditEmployeeDTO modelDTO);
        Task RemoveEmployee(int id);
        IEnumerable<EmployeeDTO> GetEmployees();
    }
}
