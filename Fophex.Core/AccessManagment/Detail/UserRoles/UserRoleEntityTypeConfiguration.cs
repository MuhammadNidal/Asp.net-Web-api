using Fophex.Core.AccessManagment.Detail.RoleRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.UserRoles
{
    public class UserRoleEntityTypeConfiguration :IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();



            builder.HasOne(userRole => userRole.User) // The foreign key property is on User
               .WithMany(user => user.UserRoles) // The navigation property in Module representing the collection of SubModules
               .HasForeignKey(userRole => userRole.UserId) // Foreign key property in User
               .IsRequired(true) // Set the foreign key as required
                                 //.OnDelete(DeleteBehavior.NoAction)
               ;

            builder.HasOne(userRole => userRole.Role) // The foreign key property is on Role
               .WithMany(role => role.UserRoles) // The navigation property in Module representing the collection of SubModules
               .HasForeignKey(userRole => userRole.RoleId) // Foreign key property in Role
               .IsRequired(true) // Set the foreign key as required
                                 //.OnDelete(DeleteBehavior.NoAction)
               ;
        }
    }
}
