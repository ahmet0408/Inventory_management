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
    public class ProductTranslateConfiguration : IEntityTypeConfiguration<ProductTranslate>
    {
        public void Configure(EntityTypeBuilder<ProductTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.Property(p => p.LanguageCulture);
            builder.HasOne(p => p.Product).WithMany(p => p.ProductTranslates).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
