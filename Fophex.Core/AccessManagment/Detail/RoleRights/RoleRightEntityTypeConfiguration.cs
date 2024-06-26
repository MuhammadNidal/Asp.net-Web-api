using Fophex.Core.AccessManagment.Master.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.RoleRights
{
    public class RoleRightEntityTypeConfiguration : IEntityTypeConfiguration<RoleRight>
    {
        public void Configure(EntityTypeBuilder<RoleRight> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IsAdd)
               .IsRequired(true);

            builder.Property(x => x.IsUpdate)
               .IsRequired(true);

            builder.Property(x => x.IsDelete)
               .IsRequired(true);
            builder.Property(x => x.IsView)
              .IsRequired(true);

            builder.HasOne(roleRight => roleRight.Role) // The foreign key property is on SubModule
             .WithMany(role => role.RoleRights) // The navigation property in Module representing the collection of SubModules
             .HasForeignKey(roleRight => roleRight.RoleId) // Foreign key property in SubModule
              .IsRequired(true) // Set the foreign key as required
            //   //.OnDelete(DeleteBehavior.NoAction)
               ;

            builder.HasOne(role => role.Form) // The foreign key property is on form
               .WithMany(form => form.RoleRights) // The navigation property in Module representing the collection of SubModules
               .HasForeignKey(role => role.FormId) // Foreign key property in form
               .IsRequired(true) // Set the foreign key as required
               //.OnDelete(DeleteBehavior.NoAction)
               ;
        }
    
    }
}
