using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hatogan.Application.UseCases.Animals.GetAll;
using Hatogan.Application.UseCases.Animals.Create;

namespace Hatogan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IResult> GetAnimals()
        {
            return await _mediator.Send(new GetAllAnimalsQuery());
        }

        [HttpPost]
        public async Task<IResult> CreateAnimal([FromBody]CreateAnimalCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
