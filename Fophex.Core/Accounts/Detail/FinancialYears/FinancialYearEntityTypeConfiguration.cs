using Fophex.Core.Accounts.Detail.AccountHeads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.FinancialYears
{
    public class FinancialYearEntityTypeConfiguration : IEntityTypeConfiguration<FinancialYear>
    {
        public void Configure(EntityTypeBuilder<FinancialYear> builder)
        {
            builder.Property(prop => prop.Description)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(prop => prop.FromDate)
                   //.HasDefaultValueSql("GETDATE()")
                   //.HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                   //.HasColumnType("datetime")
                   .IsRequired(true); // Required validation for FromDate property

            builder.Property(prop => prop.ToDate)
                   .IsRequired(true);// Required validation for ToDate property
                   //.HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                   //.HasColumnType("datetime"); // Additional validation rules for ToDate property

            // Add more validation rules as needed


            builder.Property(prop => prop.IsClosed)
                .IsRequired(true);
        }
    }
}
