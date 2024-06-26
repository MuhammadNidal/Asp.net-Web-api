using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.Categories
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(prop => prop.Id)
             .IsRequired(true)
             .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(prop => prop.Code)
                .IsRequired(true)
                .HasMaxLength(50);
        }
    }
}
