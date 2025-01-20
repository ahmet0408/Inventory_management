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
    public class DepartmentTranslateConfiguration : IEntityTypeConfiguration<DepartmentTranslate>
    {
        public void Configure(EntityTypeBuilder<DepartmentTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Address);
            builder.HasOne(p => p.Department).WithMany(p => p.DepartmentTranslates).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
