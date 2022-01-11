using Carter;
using Hatogan.Application.UseCases.Animals.Create;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Hatogan.Application.UseCases.Animals
{
    public class AnimalsModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //app.MapGet("api/animals",)

            app.MapPost("api/animals", (IMediator mediator, CreateAnimalCommand command) =>
            {
                mediator.Send(command);
            }).WithName("Create Animal")
             .Produces(StatusCodes.Status200OK); ;
        }
    }
}
