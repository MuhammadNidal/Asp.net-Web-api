using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Core.HumanResource.Master.GroupTypes;
using Fophex.Core.HumanResource.Master.Teams;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master.GroupTypes
{
    public class GroupTypeAppService : IGroupTypeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public GroupTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateGroupTypeDto createGroupTypeDto)
        {
            var groupTypeEntity = _mapper.Map<GroupType>(createGroupTypeDto);
            _dbContext.Add(groupTypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(groupTypeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var goupTypeEntities = await _dbContext.GroupTypes.Include(row=>row.Groups).ToListAsync();
            _response.Success(goupTypeEntities);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var groupTypeEntity = await _dbContext.GroupTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (groupTypeEntity != null)
            {
                _response.Success(groupTypeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateGroupTypeDto updateGroupTypeDto)
        {
            var groupTypeEntity = await _dbContext.GroupTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (groupTypeEntity != null)
            {
                groupTypeEntity!.Name = updateGroupTypeDto.Name;
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
            var groupTypeEntity = await _dbContext.GroupTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (groupTypeEntity != null)
            {


                groupTypeEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }

      
    }
}
