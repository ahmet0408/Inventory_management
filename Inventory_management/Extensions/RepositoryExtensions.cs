using Inventory_management.bll.Services.CompanyService;
using Inventory_management.bll.Services.DepartmentService;
using Inventory_management.bll.Services.EmployeeService;
using Inventory_management.bll.Services.ImageService;
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
            services.AddTransient<IImageService, ImageService>();
            return services;
        }
    }
}
