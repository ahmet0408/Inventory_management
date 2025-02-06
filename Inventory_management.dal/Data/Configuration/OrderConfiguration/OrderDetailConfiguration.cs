using Inventory_management.dal.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.OrderConfiguration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder) 
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.OrderId);
            builder.Property(p => p.Amount);
            builder.Property(p => p.ProductId);
            builder.HasOne(p => p.Order).WithMany(p => p.OrderDetails).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(p => p.OrderDetails).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
