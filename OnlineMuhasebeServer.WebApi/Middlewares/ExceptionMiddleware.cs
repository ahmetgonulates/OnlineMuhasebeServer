
using FluentValidation;

namespace OnlineMuhasebeServer.WebApi.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context,exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

            if(exception.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = (int)StatusCodes.Status400BadRequest,
                    Errors = ((ValidationException)exception).Errors.Select(x=>x.PropertyName)
                }.ToString());
            }


            return context.Response.WriteAsync(new ErrorResult
            {
                Message = exception.Message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }
    }
}
