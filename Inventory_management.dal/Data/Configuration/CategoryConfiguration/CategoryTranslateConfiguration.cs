using Inventory_management.dal.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.CategoryConfiguration
{
    public class CategoryTranslateConfiguration : IEntityTypeConfiguration<CategoryTranslate>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.LanguageCulture);
            builder.HasOne(p => p.Category).WithMany(p => p.CategoryTranslates).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
