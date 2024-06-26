﻿using Fophex.Core.HumanResource.Master.Qualifications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Cadres
{
    internal class CadreEntityTypeConfiguration : IEntityTypeConfiguration<Cadre>
    {
        public void Configure(EntityTypeBuilder<Cadre> builder)
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