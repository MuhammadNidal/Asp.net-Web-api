using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.SubClassifications
{
    public class SubClassifcationEntityTypeConfiguration : IEntityTypeConfiguration<SubClassification>
    {
        public void Configure(EntityTypeBuilder<SubClassification>builder)
        {
            builder.Property(prop => prop.Id)
              .IsRequired(true)
              .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(prop => prop.Code)
                .IsRequired(true)
                .HasMaxLength(50);

            // Configure the relationship
            builder.HasOne(suc => suc.Classification)
                .WithMany(cf => cf.SubClassifications)
                .HasForeignKey(suc => suc.ClassificationId);

        }
    }
}
