using Inventory_management.dal.Models.Category;
using Inventory_management.dal.Models.Company;
using Inventory_management.dal.Models.Customer;
using Inventory_management.dal.Models.Department;
using Inventory_management.dal.Models.Employee;
using Inventory_management.dal.Models.Language;
using Inventory_management.dal.Models.Product;
using Inventory_management.dal.Models.Rent;
using Inventory_management.dal.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Rent> Rent { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Применение всех конфигурация в сборке
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
