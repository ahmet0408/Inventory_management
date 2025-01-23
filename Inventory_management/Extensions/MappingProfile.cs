using AutoMapper;
using Inventory_management.bll.DTOs.CategoryDTO;
using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.bll.DTOs.EmployeeDTO;
using Inventory_management.dal.Models.Category;
using Inventory_management.dal.Models.Company;
using Inventory_management.dal.Models.Department;
using Inventory_management.dal.Models.Employee;
using System.Linq;

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
            CreateMap<Department, DepartmentDTO>()
                .ForMember(p => p.Name, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.Address, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.Address).FirstOrDefault()))
                .ForMember(p => p.LanguageCulture, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.LanguageCulture).FirstOrDefault()));

            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CategoryTranslateDTO, CategoryTranslate>().ReverseMap();

        }
    }
}
