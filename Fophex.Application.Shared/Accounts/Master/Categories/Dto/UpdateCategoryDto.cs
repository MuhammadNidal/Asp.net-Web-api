using System; // Importing the System namespace for basic functionalities
using System.Collections.Generic; // Importing namespaces for working with collections
using System.ComponentModel.DataAnnotations; // Importing namespace for data annotations
using System.Linq; // Importing namespaces for LINQ queries
using System.Text; // Importing namespaces for working with strings
using System.Threading.Tasks; // Importing namespaces for working with asynchronous tasks

namespace Fophex.Application.Shared.Accounts.Master.Categories.Dto
{
    public class UpdateCategoryDto // Defining a class named UpdateCategoryDto for updating category information
    {
        [Required] // Applying a validation attribute to require the 'Name' property
        public string Name { get; set; } // Defining a property for the updated category name

        [Required] // Applying a validation attribute to require the 'Code' property
        public int Code { get; set; } // Defining a property for the updated category code
    }
}
