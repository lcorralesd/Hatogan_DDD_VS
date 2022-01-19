using Hatogan.Domain.Exceptions;
using Hatogan.Domain.Wrappers;
using System.Net;
using System.Text.Json;

namespace Hatogan.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string> { Succesful = false, Message = error?.Message };

                switch (error)
                {
                    case GeneralException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ApiValidationException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException:
                        response.StatusCode= (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);

            }
        }
    }
}
