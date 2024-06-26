using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.BusinessActivities
{
    public class BusinessActivityEntityTypeConfiguration : IEntityTypeConfiguration<BusinessActivity>
    {
        public void Configure(EntityTypeBuilder<BusinessActivity> builder)
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
