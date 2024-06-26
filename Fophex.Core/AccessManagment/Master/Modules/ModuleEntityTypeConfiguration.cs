using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.Modules
{
    public class ModuleEntityTypeConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(x => x.Url)
               .IsRequired(true)
               .HasMaxLength(200); // adjust max length as necessary
            builder.Property(x => x.Icon)
               .IsRequired(true)
               .HasMaxLength(100);
            builder.Property(x => x.Sequence)
              .IsRequired(true)
              .HasAnnotation("MinValue", 1); 
        }
    }
}
