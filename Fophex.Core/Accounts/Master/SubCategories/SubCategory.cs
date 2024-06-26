// This file belongs to the SubCategories namespace in the Fophex.Core.Accounts.Master namespace.
// It's a class representing a subcategory of accounts.

// Importing necessary interfaces and classes.
using Fophex.Application.Shared.Common.Interfaces; // Interfaces used for shared functionality.
using Fophex.Core.Accounts.Master.Categories; // The Category class used for categorization.
using Fophex.Core.Accounts.Master.Classifications; // The Classification class for categorizing further.

// Importing necessary libraries.
using System; // Basic system functionality.
using System.Collections.Generic; // Provides collections like List<T> and Dictionary<T>.
using System.ComponentModel.DataAnnotations.Schema; // Used for specifying database-related attributes.
using System.Linq; // Provides LINQ functionalities for querying collections.
using System.Text; // Provides classes for working with strings.
using System.Threading.Tasks; // Provides classes for asynchronous programming.

namespace Fophex.Core.Accounts.Master.Sub_Categories
{
    // Declaring the SubCategory class.
    [Table(name: "SubCategories", Schema = "account")] // Mapping this class to a table named "SubCategories" in the "account" schema.

    // The SubCategory class inherits properties from the AuditedEntity class and implements the IMustHaveTenant interface.
    // AuditedEntity likely contains properties for auditing purposes (e.g., creation date, last modification date, etc.).
    // IMustHaveTenant indicates that an instance of this class must belong to a specific tenant.
    public class SubCategory : AuditedEntity, IMustHaveTenant
    {
        // Declaring properties for the SubCategory class.

        // Unique identifier for the subcategory.
        public long Id { get; set; }

        // The name of the subcategory. This is a required field.
        public required string Name { get; set; }

        // A code representing the subcategory.
        public int Code { get; set; }

        // The ID of the tenant to which this subcategory belongs.
        public long? TenantId { get; set; }

        // The ID of the category to which this subcategory belongs.
        public long? CategoryId { get; set; }

        // Navigation property representing the category to which this subcategory belongs.
        public Category Category { get; set; }

        // Collection of classifications associated with this subcategory.
        public ICollection<Classification> Classifications { get; set; }
    }
}
