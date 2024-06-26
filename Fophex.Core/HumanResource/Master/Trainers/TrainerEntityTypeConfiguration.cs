using Fophex.Core.HumanResource.Master.Designations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Trainers
{
   
        internal class TrainerEntityTypeConfiguration : IEntityTypeConfiguration<Trainer>
        {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            // Specifies that the 'Id' property is required (cannot be null)
            builder.Property(prop => prop.Id)
                // Indicates that the value for 'Id' should be generated automatically upon insertion (e.g., auto-incremented)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            // Specifies that the 'Name' property is required (cannot be null)
            builder.Property(prop => prop.Name)
                .IsRequired(true)
                // Sets the maximum allowed length for the 'Name' property to 50 characters
                .HasMaxLength(50);
        }

    }
}

