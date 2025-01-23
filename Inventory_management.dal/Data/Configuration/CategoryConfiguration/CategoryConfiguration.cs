﻿using Inventory_management.dal.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.CategoryConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Order);
            builder.Property(p => p.IsPublish);
            builder.HasMany(p => p.Categories).WithOne(p => p.ParentCategory).HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.Restrict).IsRequired(false); ;
            builder.HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.CategoryTranslates).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
