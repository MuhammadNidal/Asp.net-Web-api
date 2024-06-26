using Fophex.Core.Accounts.Master.Categories; // Importing namespace for the Category class
using Fophex.Core.Accounts.Master.SubClassifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; // Importing namespace for EntityTypeBuilder
using System; // Importing the System namespace for basic functionalities
using System.Collections.Generic; // Importing namespaces for working with collections
using System.Linq; // Importing namespaces for LINQ queries
using System.Text; // Importing namespaces for working with strings
using System.Threading.Tasks; // Importing namespaces for working with asynchronous tasks

namespace Fophex.Core.Accounts.Master.Sub_Categories
{
    public class SubCategoryEntityTypeConfiguration : IEntityTypeConfiguration<SubCategory>  // Defining a class for configuring SubCategory entity type
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder) // Defining a method to configure SubCategory entity type using EntityTypeBuilder
        {
            // Configuring the 'Id' property of SubCategory entity
            builder.Property(prop => prop.Id)
                 .IsRequired(true) // Setting the 'Id' property as required
                 .ValueGeneratedOnAdd(); // Generating values for 'Id' property on add

            // Configuring the 'Name' property of SubCategory entity
            builder.Property(prop => prop.Name)
                .IsRequired(true) // Setting the 'Name' property as required
                .HasMaxLength(50); // Setting maximum length for 'Name' property

            // Configuring the 'Code' property of SubCategory entity
            builder.Property(prop => prop.Code)
                .IsRequired(true) // Setting the 'Code' property as required
                .HasMaxLength(50); // Setting maximum length for 'Code' property

            // Configuring the relationship between SubCategory and Category entities
            builder.HasOne(sc => sc.Category) // Defining a one-to-many relationship between SubCategory and Category
               .WithMany(c => c.SubCategories) // Specifying that a Category can have many SubCategories
               .HasForeignKey(sc => sc.CategoryId); // Specifying the foreign key property for the relationship
        }
    }
}
