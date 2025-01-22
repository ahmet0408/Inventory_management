using Inventory_management.dal.Models.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_management.dal.Data.Configuration.ProductConfiguration
{
    public class DepartmentTranslateConfiguration : IEntityTypeConfiguration<DepartmentTranslate>
    {
        public void Configure(EntityTypeBuilder<DepartmentTranslate> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Address);
            builder.Property(p => p.LanguageCulture);
            builder.HasOne(p => p.Department).WithMany(p => p.DepartmentTranslates).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
