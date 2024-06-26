using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.Classifications
{
    public class ClassificationEntityTypeConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
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

           // Configuration the relationship
            builder.HasOne(cf => cf.SubCategory)
                .WithMany(sc => sc.Classifications)
                .HasForeignKey(cf => cf.SubCategoryId);
        }
    }
}
