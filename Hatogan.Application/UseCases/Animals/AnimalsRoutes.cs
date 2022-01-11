using Hatogan.Application.UseCases.Animals.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.UseCases.Animals
{
    public class AnimalsRoutes
    {
        public async Task<IResult> CreateAnimal(IMediator mediator, CreateAnimalCommand command)
        {
            return Results.Ok(await mediator.Send(command));
        }
    }
}
