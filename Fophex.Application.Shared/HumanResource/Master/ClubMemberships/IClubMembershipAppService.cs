using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.ClubMemberships
{
    
        public interface IClubMembershipAppService
        {
            Task<ResponseOutputDto> Add(CreateClubMembershipDto createClubMembershipDto);

            Task<ResponseOutputDto> GetAll();
            Task<ResponseOutputDto> GetById(long id);
            Task<ResponseOutputDto> Update(long id, UpdateClubMembershipDto updateClubMembershipDto);
            Task<ResponseOutputDto> Delete(long id);
        }
    }
