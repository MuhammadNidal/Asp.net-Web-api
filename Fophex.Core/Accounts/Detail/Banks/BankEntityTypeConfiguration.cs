using Fophex.Core.Accounts.Detail.AccountHeads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.Banks
{
    public class BankEntityTypeConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(prop => prop.ShortName)
                .IsRequired(true)
                .HasMaxLength(50);

        }
    }
}
