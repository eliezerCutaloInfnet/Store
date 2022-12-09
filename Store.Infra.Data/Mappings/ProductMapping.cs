using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infra.Data.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder
                .HasKey(p => p.Id).IsClustered(false);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Ignore(o => o.CascadeMode);

            builder
                .Ignore(o => o.ClassLevelCascadeMode);

            builder
                .Ignore(o => o.RuleLevelCascadeMode);

            builder
                .Ignore(o => o.ValidationResult);
        }
    }
}
