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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.OrderType);
            builder.Property(p => p.Status).HasDefaultValue(OrderStatus.Processing);
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.UpdatedAt);
            builder.Property(p => p.EmployeeId);
            builder.Property(p => p.UserId);
            builder.Property(p => p.CustomerId);
            builder.HasOne(p => p.Employee).WithMany(p => p.Orders).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.User).WithMany(p => p.Orders).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.OrderDetails).WithOne(p => p.Order).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
