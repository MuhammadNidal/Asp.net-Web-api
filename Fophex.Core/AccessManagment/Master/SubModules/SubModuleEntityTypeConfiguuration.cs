using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.SubModules
{
    public class SubModuleEntityTypeConfiguuration : IEntityTypeConfiguration<SubModule>
    {
        public void Configure(EntityTypeBuilder<SubModule> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);

           
            builder.Property(x => x.Icon)
               .IsRequired(true)
               .HasMaxLength(100);
            builder.Property(x => x.Sequence)
              .IsRequired(true)
              .HasAnnotation("MinValue", 1);

            builder.HasOne(subModule => subModule.Module) // The foreign key property is on SubModule
                .WithMany(module => module.SubModules) // The navigation property in Module representing the collection of SubModules
                .HasForeignKey(subModule => subModule.ModuleId) // Foreign key property in SubModule
                .IsRequired(true) // Set the foreign key as required
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
