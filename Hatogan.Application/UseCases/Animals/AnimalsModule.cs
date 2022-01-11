using Carter;
using Hatogan.Application.UseCases.Animals.Create;
using Hatogan.Application.UseCases.Animals.GetAll;
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
            app.MapGet("api/animals", (IMediator mediator) =>
                mediator.Send(new GetAllAnimalsQuery()));

            app.MapPost("api/animals", (IMediator mediator, CreateAnimalCommand command) =>
            {
                mediator.Send(command);
            }).WithName("Create Animal")
             .Produces(StatusCodes.Status200OK); ;
        }
    }
}
