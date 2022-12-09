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
    internal class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");

            builder
                .HasKey(op => op.Id).IsClustered(false);

            builder
                .Property(op => op.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(p => p.CurrentPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(op => op.Quantity)
                .IsRequired();

            builder
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            builder
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

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
