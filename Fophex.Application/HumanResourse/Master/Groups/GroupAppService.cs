using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Groups;
using Fophex.Application.Shared.HumanResource.Master.Groups.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;

using Fophex.Core.HumanResource.Master.Groups;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Fophex.Application.HumanResourse.Master.Groups
{
    public class GroupAppService : IGroupAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public GroupAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateGroupDto createGroupDto)
        {
            var groupEntity = _mapper.Map<Group>(createGroupDto);
            _dbContext.Add(groupEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(groupEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var goupEntities  = await _dbContext.Groups.Include(row =>row.GroupType)
                .Select(row => new GetAllGroupDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    GroupType = new GetByIdGroupTypeDto
                    {
                        Id = row.GroupType.Id,
                        Name = row.GroupType.Name,
                        CreatedBy = row.GroupType.CreatedBy,
                        CreatedDate = row.GroupType.CreatedDate,
                        UpdatedBy = row.GroupType.UpdatedBy,
                        UpdatedDate = row.GroupType.UpdatedDate,
                    }

                }).ToListAsync();
            _response.Success(goupEntities);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var groupEntity = await _dbContext.Groups
                .Include(row => row.GroupType)
                .Select(row => new GetAllGroupDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    GroupType = new GetByIdGroupTypeDto
                    {
                        Id = row.GroupType.Id,
                        Name = row.GroupType.Name,
                        CreatedBy = row.GroupType.CreatedBy,
                        CreatedDate = row.GroupType.CreatedDate,
                        UpdatedBy = row.GroupType.UpdatedBy,
                        UpdatedDate = row.GroupType.UpdatedDate,
                    }

                }).SingleOrDefaultAsync(x => x.Id == id);
            if (groupEntity != null)
            {
                _response.Success(groupEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateGroupDto updateGroupDto)
        {
            var groupEntity = await _dbContext.Groups.SingleOrDefaultAsync(x => x.Id == id); // Corrected 'id' to 'Id'
            if (groupEntity != null)
            {
                groupEntity!.Name = updateGroupDto.Name;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }

            return _response;
        }


        public async Task<ResponseOutputDto> Delete(long id)
        {
            var groupEntity = await _dbContext.Groups.SingleOrDefaultAsync(x => x.Id == id);
            if (groupEntity != null)
            {


                groupEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
