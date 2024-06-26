using Fophex.Application.Shared.Common.Dto;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Fophex.API.Middleware
{
    public class FophexExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public FophexExceptionHandlingMiddleware(RequestDelegate next, ILogger<FophexExceptionHandlingMiddleware> logger)
        {
            _next = next;
            //_logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                /*
                 if (httpContext.Response != null)
                {
                    if (httpContext.Response.StatusCode == StatusCodes.Status415UnsupportedMediaType)
                    {
                        dynamic errorObject = new ExpandoObject();
                        errorObject.error = new ExpandoObject();
                        errorObject.error.code = HttpStatusCode.UnprocessableEntity;
                        errorObject.error.message = "Validation error";
                        //errorObject.error.error_fields = new List<ExpandoObject>();
                        //errorObject.error.error_fields = dynamicList;

                        //httpContext.Result = new UnprocessableEntityObjectResult(errorObject);
                        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new UnprocessableEntityObjectResult(errorObject)));
                    }
                }
                 */
            }
            catch (Exception ex)
            {                
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var _responseOutputDto = new ResponseOutputDto()
            {
                IsSuccess = false
            };


            //if (response.StatusCode == (int)HttpStatusCode.InternalServerError)
            //{
            _responseOutputDto.Message = "Internal Server errors. Check Logs!";
            var errorDetail = exception.InnerException == null ? exception.Message : exception.InnerException.Message.ToString();
            _responseOutputDto.InternalServerError<object>(new object(), errorDetail);
            //var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(myJsonInput);
            //var myJsonOutput = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);

            //Console.Write(myJsonOutput);
            //}
            //_logger.LogError(exception.Message);
            //var result = JsonSerializer.Serialize(_responseOutputDto);
            //await context.Response.WriteAsync(result);
            await context.Response.WriteAsync(
                   JsonConvert.SerializeObject(_responseOutputDto, jsonSerializerSettings));//new ResponseOutputDto ResponseModel("some-message")));

        }
    }
}
