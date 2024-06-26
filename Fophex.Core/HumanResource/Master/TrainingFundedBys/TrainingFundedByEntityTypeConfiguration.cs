using Fophex.Core.HumanResource.Master.TrainingTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.TrainingFundedBys
{
   
        internal class TrainingFundedByEntityTypeConfiguration : IEntityTypeConfiguration<TrainingFundedBy>
        {
            public void Configure(EntityTypeBuilder<TrainingFundedBy> builder)
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

