using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Net;

namespace Fophex.API.Filters
{
    public class FophexValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {                                                
                var errors = context.ModelState.Values.Select(rows => rows.Errors);
                var keys = context.ModelState.Keys.ToList();                
                int rowIndex = 0, rowCount = 1;
                string errorMessages = string.Empty;
                
                List<dynamic> dynamicList = new List<dynamic>();
                foreach (var error in errors)
                {
                    errorMessages = string.Empty;                    
                    dynamic expandoObject = new ExpandoObject();                    
                    var key = keys[rowIndex];
                    foreach (var er in error)
                    {
                        errorMessages = errorMessages == string.Empty ? (er.ErrorMessage.ToString()) : errorMessages + ", " + er.ErrorMessage.ToString();                        
                        rowCount += 1;
                    }                    
                    var properties = new Dictionary<string, object>
                                     {
                                         { key, errorMessages }
                                     };
                    
                    AddProperties(expandoObject, properties);
                    
                    dynamicList.Add(expandoObject);
                    rowIndex++;
                    
                }                
                dynamic errorObject = new ExpandoObject();
                errorObject.error = new ExpandoObject();
                errorObject.error.code = HttpStatusCode.UnprocessableEntity;
                errorObject.error.message = "Validation error";
                errorObject.error.error_fields = new List<ExpandoObject>();
                errorObject.error.error_fields = dynamicList;
                                
                context.Result = new UnprocessableEntityObjectResult(errorObject);
            }


            base.OnActionExecuting(context);
        }
        static void AddProperties(dynamic expandoObject, Dictionary<string, object> properties)
        {
            var expandoDict = (IDictionary<string, object>)expandoObject;
            foreach (var property in properties)
            {
                expandoDict[property.Key] = property.Value;
            }
        }
    }
}
