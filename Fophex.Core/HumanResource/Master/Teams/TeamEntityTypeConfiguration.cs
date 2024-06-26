using Fophex.Core.HumanResource.Master.TeamTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fophex.Core.HumanResource.Master.Teams
{
    internal class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(prop => prop.Id)
               .IsRequired(true)
               .ValueGeneratedOnAdd(); 

            builder.Property(prop => prop.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            // Configure the foreign key relationship
            builder.HasOne(team => team.TeamType)
                   .WithMany(teamType => teamType.Teams)
                   .HasForeignKey(team => team.TeamTypeId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Restrict); // or another behavior like Cascade, SetNull, etc.
        }
    }
}
