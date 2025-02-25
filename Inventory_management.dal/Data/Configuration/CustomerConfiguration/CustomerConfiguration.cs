using Inventory_management.dal.Models.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory_management.dal.Data.Configuration.CustomerConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Address);
            builder.Property(p => p.Picture);
            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.Phone);
            builder.HasMany(p => p.Rents).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
