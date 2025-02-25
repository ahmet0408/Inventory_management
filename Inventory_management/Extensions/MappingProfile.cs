using AutoMapper;
using Inventory_management.bll.DTOs.CategoryDTO;
using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using Inventory_management.bll.DTOs.CustomeDTO;
using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.bll.DTOs.EmployeeDTO;
using Inventory_management.bll.DTOs.ProductDTO;
using Inventory_management.bll.DTOs.RentDTO;
using Inventory_management.dal.Models.Category;
using Inventory_management.dal.Models.Company;
using Inventory_management.dal.Models.Customer;
using Inventory_management.dal.Models.Department;
using Inventory_management.dal.Models.Employee;
using Inventory_management.dal.Models.Product;
using Inventory_management.dal.Models.Rent;
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
            CreateMap<EditEmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(p => p.DepartmentName, p => p.MapFrom(p => p.Department.DepartmentTranslates.Select(p => p.Name).FirstOrDefault()));

            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            

            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<DepartmentTranslateDTO, DepartmentTranslate>().ReverseMap();
            CreateMap<EditDepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>()
                .ForMember(p => p.Name, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.Address, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.Address).FirstOrDefault()))
                .ForMember(p => p.LanguageCulture, p => p.MapFrom(p => p.DepartmentTranslates.Select(p => p.LanguageCulture).FirstOrDefault()));

            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CategoryTranslateDTO, CategoryTranslate>().ReverseMap();
            CreateMap<EditCategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>()
                .ForMember(p => p.ParentCategory, p => p.MapFrom(p => p.ParentCategory.CategoryTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.Name, p => p.MapFrom(p => p.CategoryTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.LanguageCulture, p => p.MapFrom(p => p.CategoryTranslates.Select(p => p.LanguageCulture).FirstOrDefault()));

            CreateMap<CreateProductDTO, Product>();
            CreateMap<ProductTranslateDTO, ProductTranslate>().ReverseMap();
            CreateMap<EditProductDTO, Product>();
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.CategoryName, p => p.MapFrom(p => p.Category.CategoryTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.DepartmentName, p => p.MapFrom(p => p.Department.DepartmentTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.EmployeeName, p => p.MapFrom(p => p.Employee.FullName))
                .ForMember(p => p.Name, p => p.MapFrom(p => p.ProductTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.Description, p => p.MapFrom(p => p.ProductTranslates.Select(p => p.Description).FirstOrDefault()))
                .ForMember(p => p.LanguageCulture, p => p.MapFrom(p => p.ProductTranslates.Select(p => p.LanguageCulture).FirstOrDefault()));

            CreateMap<RentDetailDTO, RentDetail>();
            CreateMap<RentDTO, Rent>();
            CreateMap<Rent, RentDTO>()
                .ForMember(p => p.ResponsibleEmployee, p => p.MapFrom(p => (p.User.FirstName + " " + p.User.LastName)))
                .ForMember(p => p.Customer, p => p.MapFrom(p => (p.Customer.FirstName + " " + p.Customer.LastName)))
                .ForMember(p => p.CustomerPicture, p => p.MapFrom(p => p.Customer.Picture))
                .ForMember(p => p.RentNumber, p => p.MapFrom(p => p.Id));
            CreateMap<RentDetail, RentDetailDTO>()
                .ForMember(p => p.Barcode, p => p.MapFrom(p => p.Product.Barcode))
                .ForMember(p => p.Name, p => p.MapFrom(p => p.Product.ProductTranslates.Select(p => p.Name).FirstOrDefault()))
                .ForMember(p => p.Description, p => p.MapFrom(p => p.Product.ProductTranslates.Select(p => p.Description).FirstOrDefault()))
                .ForMember(p => p.Image, p => p.MapFrom(p => p.Product.Image))
                .ForMember(p => p.Price, p => p.MapFrom(p => p.Product.Price));
        }
    }
}
