using GameAPI.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GameAPI.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException error)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(error.Message);
                context.ExceptionHandled = true;

                //var problem = new ProblemDetails
                //{
                //    Title = "Erro de validação",
                //    Detail = error.Message,
                //    Status = (int)HttpStatusCode.BadRequest
                //};

                //context.Result = new ObjectResult(problem)
                //{
                //    StatusCode = (int)HttpStatusCode.BadRequest
                //};
                //context.ExceptionHandled = true;
            }
            else
            {
                ThrowUnknowException(context);
            }
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
        }
    }
}