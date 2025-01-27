using Inventory_management.dal.Models.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data.Configuration.CompanyConfiguration
{
    public class CompanyConfiguration: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.Property(p => p.Address);
            builder.Property(p => p.Phone);
            builder.Property(p => p.Email);
            builder.Property(p => p.IsPublish);
        }
    }
}
