using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Core.HumanResource.Master.Teams;
using Fophex.Core.HumanResource.Master.TeamTypes;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master.Teams
{
    public class TeamAppService : ITeamAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TeamAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTeamDto createTeamDto)
        {
            var teamEntity = _mapper.Map<Team>(createTeamDto);
            _dbContext.Add(teamEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(teamEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var teamEntities = await _dbContext.Teams.Include(row => row.TeamType)
                .Select(row => new GetAllTeamDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    TenantId = row.TenantId,
                    CreatedBy  = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    TeamType = new GetByIdTeamTypeDto
                    {
                        Id = row.TeamType.Id,
                        Name = row.TeamType.Name,
                        CreatedBy = row.TeamType.CreatedBy,
                        CreatedDate = row.TeamType.CreatedDate,
                        UpdatedBy = row.TeamType.UpdatedBy,
                        UpdatedDate = row.TeamType.UpdatedDate,
                    }

                }).ToListAsync();
            _response.Success(teamEntities);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var teamEntity = await _dbContext.Teams.Include(row => row.TeamType)
                .Select(row => new GetByIdTeamDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    TeamType = new GetByIdTeamTypeDto
                    {
                        Id = row.TeamType.Id,
                        Name = row.TeamType.Name,
                        CreatedBy = row.TeamType.CreatedBy,
                        CreatedDate = row.TeamType.CreatedDate,
                        UpdatedBy = row.TeamType.UpdatedBy,
                        UpdatedDate = row.TeamType.UpdatedDate,
                    }
                
               }) .SingleOrDefaultAsync(x => x.Id == id);
            if (teamEntity != null)
            {
                _response.Success(teamEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTeamDto updateTeamDto)
        {
            var teamEntity = await _dbContext.Teams.SingleOrDefaultAsync(x => x.Id == id);
            if (teamEntity != null)
            {
                teamEntity!.Name = updateTeamDto.Name;
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
            var teamEntity = await _dbContext.Teams.SingleOrDefaultAsync(x => x.Id == id);
            if (teamEntity != null)
            {


                teamEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
   
}
