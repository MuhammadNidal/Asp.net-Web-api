using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Common.Dto
{
    public class ResponseOutputDto
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

        public void Success<DtoType>(DtoType Data, string message = null) where DtoType : class
        {
            this.IsSuccess = true;
            this.Status = "Success";
            this.Message = message == null ? "Success" : message;
            this.Data = Data;
        }
        public void Error(string? message = null)
        {
            this.IsSuccess = false;
            this.Status = "Error";
            this.Message = message == null ? "An error occured while processing your request" : message;
            this.Data = new object();
        }
        public void Invalid(string? message = null)
        {
            this.IsSuccess = false;
            this.Status = "Invalid";
            this.Message = message == null ? "An error occured while processing your request" : message;
            this.Data = new object();
        }
        public void Warning(string? message = null)
        {
            this.IsSuccess = false;
            this.Status = "Warning";
            this.Message = message == null ? "An error occured while processing your request" : message;
            this.Data = new object();
        }
        public void BadRequest<DtoType>(DtoType Data) where DtoType : class
        {
            this.IsSuccess = false;
            this.Status = "400";
            this.Message = "Bad Request";
            this.Data = Data;
        }
        public ResponseOutputDto Status401Unauthorized()
        {
            ResponseOutputDto responseOutputDto = new ResponseOutputDto();
            responseOutputDto.IsSuccess = false;
            responseOutputDto.Status = "Unauthorized";
            responseOutputDto.Message = "You're Unauthorized either do not have valid token";
            responseOutputDto.Data = new object();
            return responseOutputDto;
        }
        public void InternalServerError<DtoType>(DtoType Data, string message) where DtoType : class
        {
            this.IsSuccess = false;
            this.Status = "500";
            this.Message = message;
            this.Data = Data;
        }
    }
}
