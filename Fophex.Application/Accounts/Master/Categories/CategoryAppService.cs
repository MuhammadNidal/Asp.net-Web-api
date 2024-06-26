using AutoMapper; // Importing AutoMapper for object-to-object mapping
using Fophex.Application.Shared.Accounts.Master.Categories; // Importing namespaces for Categories
using Fophex.Application.Shared.Accounts.Master.Categories.Dto; // Importing namespaces for Category DTOs
using Fophex.Application.Shared.Common.Dto; // Importing namespaces for common DTOs
using Fophex.Application.Shared.Test.Dto; // Importing namespaces for test DTOs
using Fophex.Core.Accounts.Master.Categories; // Importing namespaces for Category core logic
using Fophex.Core.Test; // Importing namespaces for test core logic
using Fophex.EntityFrameworkCore; // Importing namespaces for Entity Framework Core
using Microsoft.EntityFrameworkCore; // Importing namespaces for EF Core
using System; // Importing the System namespace for basic functionalities
using System.Collections.Generic; // Importing namespaces for working with collections
using System.Linq; // Importing namespaces for LINQ queries
using System.Text; // Importing namespaces for working with strings
using System.Threading.Tasks; // Importing namespaces for working with asynchronous tasks

namespace Fophex.Application.Accounts.Master.Categories
{
    public class CategoryAppService : ICategoryAppService // Defining a class named CategoryAppService implementing ICategoryAppService interface
    {
        ApplicationDbContext _dbContext; // Declaring a private field to hold an instance of ApplicationDbContext
        private readonly IMapper _mapper; // Declaring a private field to hold an instance of IMapper

        ResponseOutputDto _response; // Declaring a private field to hold an instance of ResponseOutputDto

        // Constructor to initialize CategoryAppService with an instance of ApplicationDbContext and IMapper
        public CategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext; // Initializing _dbContext with the provided instance of ApplicationDbContext
            _mapper = mapper; // Initializing _mapper with the provided instance of IMapper

            // Checking if _response is null and initializing it with a new instance of ResponseOutputDto if it is
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        // Method to add a new category
        public async Task<ResponseOutputDto> Add(CreateCategoryDto createCategoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(createCategoryDto); // Mapping CreateCategoryDto to Category entity
            _dbContext.Add(categoryEntity); // Adding the categoryEntity to the _dbContext
            var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database asynchronously
            _response.Success(result.ToString()); // Setting success response with the result
            return _response; // Returning the response
        }

        // Method to get all categories
        public async Task<ResponseOutputDto> GetAll()
        {
            var categoryEntities = await _dbContext.Categories.Include(child => child.SubCategories).ToListAsync(); // Retrieving all categories from the database asynchronously
            _response.Success(categoryEntities); // Setting success response with the retrieved categories
            return _response; // Returning the response
        }

        // Method to get category by its id
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var categoryEntity = await _dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id); // Retrieving a category by its id asynchronously
            if (categoryEntity != null) // Checking if categoryEntity is not null
            {
                _response.Success(categoryEntity!); // Setting success response with the retrieved category
            }
            else // If categoryEntity is null
            {
                _response.Invalid($"Entity not found for id {id}"); // Setting invalid response indicating category not found
            }
            return _response; // Returning the response
        }

        // Method to update a category
        public async Task<ResponseOutputDto> Update(long id, UpdateCategoryDto updateCategoryDto)
        {
            var categoryEntity = await _dbContext.Categories.FindAsync(id); // Retrieving a category by its id asynchronously
            if (categoryEntity != null) // Checking if categoryEntity is not null
            {
                categoryEntity!.Name = updateCategoryDto.Name; // Updating the category name
                var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database asynchronously
                _response.Success(result.ToString()); // Setting success response with the result
            }
            else // If categoryEntity is null
            {
                _response.Invalid($"Entity not found for id {id}"); // Setting invalid response indicating category not found
            }
            return _response; // Returning the response
        }

        // Method to delete a category
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var categoryEntity = await _dbContext.Categories.FindAsync(id); // Retrieving a category by its id asynchronously
            if (categoryEntity != null) // Checking if categoryEntity is not null
            {
                categoryEntity!.IsDeleted = true; // Marking the category as deleted
                var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database asynchronously
                _response.Success(result.ToString()); // Setting success response with the result
                return _response; // Returning the response
            }
            else // If categoryEntity is null
            {
                _response.Invalid($"Entity not found for id {id}"); // Setting invalid response indicating category not found
                return _response; // Returning the response
            }
        }
    }
}
