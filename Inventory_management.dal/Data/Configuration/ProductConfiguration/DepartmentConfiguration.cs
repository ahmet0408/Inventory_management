using Inventory_management.dal.Models.Department;
using Inventory_management.dal.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.ProductConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Products).WithOne(p => p.Department).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Employees).WithOne(p => p.Department).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.DepartmentTranslates).WithOne(p => p.Department).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
