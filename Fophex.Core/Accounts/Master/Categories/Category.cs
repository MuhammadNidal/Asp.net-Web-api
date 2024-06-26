using Fophex.Application.Shared.Common.Interfaces; // Importing namespace for common interfaces
using Fophex.Core.Accounts.Master.Sub_Categories; // Importing namespace for SubCategory class
using System; // Importing the System namespace for basic functionalities
using System.Collections.Generic; // Importing namespaces for working with collections
using System.ComponentModel.DataAnnotations.Schema; // Importing namespace for defining database schema
using System.Linq; // Importing namespaces for LINQ queries
using System.Text; // Importing namespaces for working with strings
using System.Threading.Tasks; // Importing namespaces for working with asynchronous tasks

namespace Fophex.Core.Accounts.Master.Categories
{
    [Table(name: "Categories", Schema = "account")] // Defining table name and schema for Category entity in the database
    public class Category : AuditedEntity, IMustHaveTenant // Defining a class named Category that inherits from AuditedEntity and implements IMustHaveTenant interface
    {
        public long Id { get; set; } // Defining a property for Category Id
        public string Name { get; set; } = string.Empty; // Defining a property for Category Name with default value of empty string
        public int Code { get; set; } // Defining a property for Category Code
        public long? TenantId { get; set; } // Defining a property for TenantId (nullable)
        public ICollection<SubCategory> SubCategories { get; set; } // Defining a collection navigation property for SubCategories associated with this Category
    }
}
