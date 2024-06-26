using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Core.Accounts.Master.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.AccountHeads
{
    public class AccountHeadEntityTypeConfiguration : IEntityTypeConfiguration<AccountHead>
    {
        public void Configure(EntityTypeBuilder<AccountHead> builder)
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

            builder.Property(prop => prop.OpeningBalance);
                
            builder.Property(prop => prop.IsControlAccount);

            builder.Property(prop => prop.IsDebit);

            builder.Property(prop => prop.IsCredit);

            //builder.HasOne(ah => ah.SubClassification) // The foreign key property is on form
            //   .WithMany(su => su.AccountHeads  ) // The navigation property in Module representing the collection of SubModules
            //   .HasForeignKey(ah => ah.SubClassificationId) // Foreign key property in form
            //   .IsRequired(true);// Set the fore

            //builder.HasOne(tn => tn.Tenant) // The foreign key property is on form
            // .WithMany(su => su.AccountHeads) // The navigation property in Module representing the collection of SubModules
            // .HasForeignKey(ah => ah.Tenant) // Foreign key property in form
            // .IsRequired(true);// Set the fore

        }

    }
}
