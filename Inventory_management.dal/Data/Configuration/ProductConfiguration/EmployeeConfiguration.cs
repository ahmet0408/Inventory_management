using Inventory_management.dal.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.ProductConfiguration
{
    public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName);
            builder.Property(p => p.Job);
            builder.Property(p => p.Picture);
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.PassportFile);
            builder.HasOne(p => p.Department).WithMany(p => p.Employees).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Products).WithOne(p => p.Employee).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
