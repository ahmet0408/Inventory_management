using Inventory_management.bll.Services.CategoryService;
using Inventory_management.bll.Services.CompanyService;
using Inventory_management.bll.Services.DepartmentService;
using Inventory_management.bll.Services.EmployeeService;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.bll.Services.ProductService;
using Inventory_management.bll.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_management.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ICategoryService,  CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
