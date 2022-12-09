using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Mappings
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder
                .HasKey(o => o.Id).IsClustered(false);

            builder
                .Property(o => o.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(o => o.Status)
                .IsRequired();

            builder
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

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
