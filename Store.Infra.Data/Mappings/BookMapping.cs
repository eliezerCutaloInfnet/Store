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
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder
                .HasKey(p => p.Id).IsClustered(false);

            builder
                .Property(p => p.Title)
                .IsRequired();

            builder
                .Property(p => p.Genre)
                .IsRequired();

            builder
                .Property(p => p.Summary)
                .IsRequired();

            builder
                .Property(p => p.Isbn)
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
