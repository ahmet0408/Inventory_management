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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount);
            builder.Property(p => p.Barcode);
            builder.Property(p => p.Price);
            builder.Property(p => p.Status);
            builder.Property(p => p.ArrivalAt);
            builder.HasOne(p => p.Department).WithMany(p => p.Products).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.ProductTranslates).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
