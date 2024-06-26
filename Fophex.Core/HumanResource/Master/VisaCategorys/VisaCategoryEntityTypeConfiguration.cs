using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.VisaCategorys
{
    internal class VisaCategoryEntityTypeConfiguration : IEntityTypeConfiguration<VisaCategory>
    {
        public void Configure(EntityTypeBuilder<VisaCategory> builder)
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
