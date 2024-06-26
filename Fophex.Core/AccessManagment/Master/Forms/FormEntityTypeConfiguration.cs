using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.Forms
{
    public class FormEntityTypeConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Url)
               .IsRequired(true)
               .HasMaxLength(200); // adjust max length as necessary
          
            builder.Property(x => x.Sequence)
              .IsRequired(true)
              .HasAnnotation("MinValue", 1);

            builder.HasOne(form => form.SubModule) // The foreign key property is on SubModule
              .WithMany(submodule => submodule.Forms) // The navigation property in Module representing the collection of SubModules
              .HasForeignKey(form => form.SubModuleId) // Foreign key property in SubModule
              .IsRequired(true) // Set the foreign key as required
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
