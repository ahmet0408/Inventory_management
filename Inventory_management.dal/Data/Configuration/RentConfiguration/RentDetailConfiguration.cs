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
    public class RentDetailConfiguration : IEntityTypeConfiguration<RentDetail>
    {
        public void Configure(EntityTypeBuilder<RentDetail> builder) 
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RentId);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.ProductId);
            builder.HasOne(p => p.Rent).WithMany(p => p.RentDetails).HasForeignKey(p => p.RentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(p => p.RentDetails).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
