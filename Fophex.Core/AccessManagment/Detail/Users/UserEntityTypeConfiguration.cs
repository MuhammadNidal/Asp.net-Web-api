using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Master.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(prop => prop.Id)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.FirstName)
                .IsRequired(false)
                .HasMaxLength(50);
            builder.Property(prop => prop.LastName)
               .IsRequired(false)
               .HasMaxLength(50);

            builder.Property(prop => prop.MobileNumber)
                 .IsRequired(true)
                 .HasMaxLength(20);
            builder.Property(prop => prop.Email)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(prop => prop.Password)
              .IsRequired(true)
              .HasMaxLength(100);
        }



    
    }
}
