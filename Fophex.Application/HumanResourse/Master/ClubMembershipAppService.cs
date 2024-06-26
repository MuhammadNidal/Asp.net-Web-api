using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;
using Fophex.Core.HumanResource.Master.ClubMemberships;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{
    
        public class ClubMembershipAppService : IClubMembershipAppService
    {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            ResponseOutputDto _response;
            public ClubMembershipAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            public async Task<ResponseOutputDto> Add(CreateClubMembershipDto createClubMembershipDto)
            {
                var ClubMembershipEntity = _mapper.Map<ClubMembership>(createClubMembershipDto);
                _dbContext.Add(ClubMembershipEntity);
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(ClubMembershipEntity);
                return _response;
            }
            public async Task<ResponseOutputDto> GetAll()
            {
                var ClubMembershipEntity = await _dbContext.ClubMemberships.ToListAsync();
                _response.Success(ClubMembershipEntity);
                return _response;
            }

            public async Task<ResponseOutputDto> GetById(long id)
            {
                var ClubMembershipEntity = await _dbContext.ClubMemberships.SingleOrDefaultAsync(x => x.Id == id);
                if (ClubMembershipEntity != null)
                {
                    _response.Success(ClubMembershipEntity!);
                }
                else
                {
                    _response.Invalid($"Entity not found for id {id}");
                }
                return _response;
            }
            public async Task<ResponseOutputDto> Update(long id, UpdateClubMembershipDto updateClubMembershipDto)
            {
                var ClubMembershipEntity = await _dbContext.ClubMemberships.SingleOrDefaultAsync(x => x.Id == id);
                if (ClubMembershipEntity != null)
                {
                ClubMembershipEntity!.Name = updateClubMembershipDto.Name;
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
                var ClubMembershipEntity = await _dbContext.ClubMemberships.SingleOrDefaultAsync(x => x.Id == id);
                if (ClubMembershipEntity != null)
                {


                ClubMembershipEntity!.IsDeleted = true;
                    var result = await _dbContext.SaveChangesAsync();
                    _response.Success(result.ToString());
                    return _response;
                }
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }
}
