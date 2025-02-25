using Inventory_management.dal.Models.Rent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.OrderConfiguration
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RentType);
            builder.Property(p => p.Status).HasDefaultValue(RentStatus.Processing);
            builder.Property(p => p.DateOfShipment);
            builder.Property(p => p.DateOfReturn);
            builder.Property(p => p.UserId);
            builder.Property(p => p.CustomerId);
            builder.HasOne(p => p.User).WithMany(p => p.Rents).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.RentDetails).WithOne(p => p.Rent).HasForeignKey(p => p.RentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
