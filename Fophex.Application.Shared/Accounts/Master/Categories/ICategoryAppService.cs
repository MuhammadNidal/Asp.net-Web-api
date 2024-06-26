using Fophex.Application.Shared.Accounts.Master.Categories.Dto;// Importing necessary namespaces for data transfer objects (DTOs).
using Fophex.Application.Shared.Common.Dto;// Importing necessary namespaces for common data transfer objects.
using System;// Importing the System namespace for basic functionalities.
using System.Collections.Generic; // Importing the System.Collections.Generic namespace for using generic collections.
using System.Linq;// Importing the System.Linq namespace for LINQ queries.
using System.Text; // Importing the System.Text namespace for string manipulation.
using System.Threading.Tasks;// Importing the System.Threading.Tasks namespace for asynchronous programming.

namespace Fophex.Application.Shared.Accounts.Master.Categories  // Declaring a namespace for the category-related application services.
{
    public interface ICategoryAppService // Defining an interface for the category application service.
    {
        // Method to add a new category, takes a DTO with category details and returns a response DTO.
        public Task<ResponseOutputDto> Add(CreateCategoryDto createCategoryDto);

        // Method to retrieve all categories, returns a response DTO containing all categories.
        public Task<ResponseOutputDto> GetAll();

        // Method to retrieve a category by its ID, takes the ID and returns a response DTO with the category details.
        public Task<ResponseOutputDto> GetById(long id);

        // Method to update a category, takes the category ID and a DTO with updated category details, returns a response DTO.
        public Task<ResponseOutputDto> Update(long id, UpdateCategoryDto updateCategoryDto);


        // Method to delete a category by its ID, takes the ID and returns a response DTO indicating the deletion status.
        public Task<ResponseOutputDto> Delete(long id);



    }
}
