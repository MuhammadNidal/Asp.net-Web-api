
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fophex.Core.HumanResource.Master.Groups
{
    internal class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(prop => prop.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(group => group.GroupType)
                  .WithMany(groupType => groupType.Groups)  // Corrected navigation property
                  .HasForeignKey(group => group.GroupTypeId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
