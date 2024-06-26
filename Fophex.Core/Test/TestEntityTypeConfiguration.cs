using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Test
{
    internal class TestEntityTypeConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            
            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);
        }
    }
}
