using Fophex.Core.HumanResource.Master.Cadres;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.ClubMemberships
{
   
        internal class ClubMembershipEntityTypeConfiguration : IEntityTypeConfiguration<ClubMembership>
        {
            public void Configure(EntityTypeBuilder<ClubMembership> builder)
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
