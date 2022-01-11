using Hatogan.Application.Infrastructure.Data;
using Hatogan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hatogan.Application.UseCases.Animals.Create
{
    public class CreateAnimalCommand : IRequest<IResult>
    {
        public string Number { get; set; } = default!;
        public string? Name { get; set; }
        public short OriginId { get; set; }
        public short SexId { get; set; }
        public short StatusId { get; set; } = 1;
        public string? Color { get; set; }
        public string? Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal BirthWeight { get; set; } = 0;
        public DateTime AdmissionDate { get; set; }
        public decimal IncomeWeight { get; set; } = 0;
        public decimal ActualWeight { get; set; } = 0;
        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }
        public string? Remarks { get; set; }


        internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, IResult>
        {
            private readonly ApplicationDbContext _context;

            public CreateAnimalCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IResult> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var newAnimal = new Animal(request.Number, request.Name, request.OriginId, request.SexId, request.StatusId, request.Color, request.Breed, request.BirthDate, request.BirthWeight, request.AdmissionDate, request.IncomeWeight, request.ActualWeight, request.SireId, request.DamId, request.Remarks);

                    _context.Animals.Add(newAnimal);

                    await _context.SaveChangesAsync();

                    var dto = new CreateAnimalDTO
                    {
                        Id = newAnimal.Id,
                        Number = newAnimal.Number,
                        Name = newAnimal.Name,
                        SexName = newAnimal.Sex.Name,
                        CategoryName = newAnimal.Category.Name,
                        Age = newAnimal.CalculateAgeDays(newAnimal.BirthDate)
                    };
                    return Results.Ok(dto);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }

    public class CreateAnimalDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = default!;
        public string? Name { get; set; }
        public string SexName { get; set; } = default!;
        public string CategoryName { get; set; } = default!;
        public int Age { get; set; }
    }
}
