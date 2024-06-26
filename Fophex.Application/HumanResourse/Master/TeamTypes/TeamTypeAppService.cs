using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes;
using Fophex.Core.HumanResource.Master.TeamTypes;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;

namespace Fophex.Application
{
    public class TeamTypeAppService : ITeamTypeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TeamTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTeamTypeDto createTeamTypeDto)
        {
            var teamTypeEntity = _mapper.Map<TeamType>(createTeamTypeDto);
            _dbContext.Add(teamTypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(teamTypeEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var teamTypeEntities = await _dbContext.TeamTypes.Include(row => row.Teams).ToListAsync();
            _response.Success(teamTypeEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var teamTypeEntity = await _dbContext.TeamTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (teamTypeEntity != null)
            {
                _response.Success(teamTypeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTeamTypeDto updateTeamTypeDto)
        {
            var teamTypeEntity = await _dbContext.TeamTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (teamTypeEntity != null)
            {
                teamTypeEntity!.Name = updateTeamTypeDto.Name;
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
            var teamTypeEntity = await _dbContext.TeamTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (teamTypeEntity != null)
            {


                teamTypeEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
