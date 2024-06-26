using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Master.Forms;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Master
{
    // This class implements the IFormAppService interface and handles operations related to forms.
    public class FormAppService : IFormAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.

        // Constructor to initialize the ModuleAppService.
        public FormAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto(); // Initializing the response object.
        }
        // Method to add a new form.
        public async Task<ResponseOutputDto> Add(CreateFormDto createFormDto)
        {
            var formEntity = _mapper.Map<Form>(createFormDto); // Mapping DTO to entity.
            _dbContext.Add(formEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database.
            _response.Success(formEntity);
            return _response;
        }
        // Method to get all forms.
        public async Task<ResponseOutputDto> GetAll()
        {
            var formEntities = await _dbContext.Forms.Include(row => row.SubModule)
                .Select(row => new GetAllFormDto
                { 
                 Id = row.Id,
                 Name = row.Name,
                 Url = row.Url,
                 Sequence = row.Sequence,
                 TenantId = row.TenantId,
                 CreatedBy = row.CreatedBy,
                 CreatedDate = row.CreatedDate,
                 UpdatedBy = row.UpdatedBy,
                 UpdatedDate = row.UpdatedDate,
                 SubModule = new GetByIdSubModuleDto
                 {
                     Id = row.SubModule.Id,
                     Name = row.SubModule.Name,
                     Icon = row.SubModule.Icon,
                     Sequence = row.SubModule.Sequence,
                     CreatedBy = row.SubModule.CreatedBy,
                     CreatedDate = row.SubModule.CreatedDate,
                     UpdatedBy = row.SubModule.UpdatedBy,
                     UpdatedDate = row.SubModule.UpdatedDate,
                 }   
                }) .ToListAsync(); // Retrieving all forms from the database.
            _response.Success(formEntities);
            return _response;
        }
        // Method to get a form by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var formEntity = await _dbContext.Forms.Include(row => row.SubModule)
                .Select(row => new GetAllFormDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    Url = row.Url,
                    Sequence = row.Sequence,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    SubModule = new GetByIdSubModuleDto
                    {
                        Id = row.SubModule.Id,
                        Name = row.SubModule.Name,
                        Icon = row.SubModule.Icon,
                        Sequence = row.SubModule.Sequence,
                        CreatedBy = row.SubModule.CreatedBy,
                        CreatedDate = row.SubModule.CreatedDate,
                        UpdatedBy = row.SubModule.UpdatedBy,
                        UpdatedDate = row.SubModule.UpdatedDate,
                    }
                }).SingleOrDefaultAsync(x => x.Id == id); // Retrieving form by ID.
            if (formEntity != null)
            {
                _response.Success(formEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to from a form.
        public async Task<ResponseOutputDto> Update(long id, UpdateFormDto updateFormDto)
        {
            var formEntity = await _dbContext.Forms.FindAsync(id); // Retrieving form by ID.
            if (formEntity != null)
            {
                formEntity.Name = updateFormDto.Name; // Updating form name.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to delete a form.
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var formEntity = await _dbContext.Forms.SingleOrDefaultAsync(x => x.Id == id); // Retrieving form by ID.
            if (formEntity != null)
            {
                formEntity.IsDeleted = true; // Marking module as deleted.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
