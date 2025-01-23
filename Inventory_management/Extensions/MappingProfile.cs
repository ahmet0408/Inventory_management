using AutoMapper;
using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.bll.DTOs.EmployeeDTO;
using Inventory_management.dal.Models.Company;
using Inventory_management.dal.Models.Department;
using Inventory_management.dal.Models.Employee;

namespace Inventory_management.Extensions
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<EditCompanyDTO, Company>().ReverseMap();
            CreateMap<Company, CompanyDTO>();

            CreateMap<CreateEmployeeDTO, Employee>();

            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<DepartmentTranslateDTO, DepartmentTranslate>().ReverseMap();
        }
    }
}
