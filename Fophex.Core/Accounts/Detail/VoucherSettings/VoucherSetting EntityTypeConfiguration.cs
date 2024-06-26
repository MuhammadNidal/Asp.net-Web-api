using Fophex.Core.Accounts.Master.SubClassifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.VoucherSettings
{
    public class VoucherSetting_EntityTypeConfiguration : IEntityTypeConfiguration<VoucherSetting>
    {
        public void Configure(EntityTypeBuilder<VoucherSetting> builder)
        {
            builder.Property(prop => prop.Id)
                .IsRequired(true)
              .ValueGeneratedOnAdd();
            builder.Property(prop => prop.CashHeadId)
                .IsRequired(true);

            builder.Property(prop => prop.BankHeadId)
               .IsRequired(true);


        }
    }
}
