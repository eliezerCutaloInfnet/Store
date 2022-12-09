using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Mappings
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder
                .HasKey(u => u.Id).IsClustered(false);

            builder
                .Property(u => u.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(u => u.Name)
                .IsRequired();

            builder
                .Property(u => u.Username)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar(200)")
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
