using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Designations
{
    public interface IDesignationAppServices
    {
        Task<ResponseOutputDto> Add(CreateDesignationDto createDesignationDto);

        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateDesignationDto updateDesignationDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
