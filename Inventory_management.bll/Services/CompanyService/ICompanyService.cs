using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CompanyService
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyDTO modelDTO);
        Task EditCompany(EditCompanyDTO modelDTO);
        Task RemoveCompany(int id);
        IEnumerable<CompanyDTO> GetCompanies();
    }
}
