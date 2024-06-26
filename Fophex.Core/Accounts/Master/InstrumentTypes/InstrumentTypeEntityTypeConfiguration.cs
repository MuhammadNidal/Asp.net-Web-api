using Fophex.Core.Accounts.Master.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.InstrumentTypes
{
   public class InstrumentTypeEntityTypeConfiguration : IEntityTypeConfiguration<InstrumentType>
    {

        public void Configure(EntityTypeBuilder<InstrumentType> builder)
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
