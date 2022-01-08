using Hatogan.Application.Interfaces;
using Hatogan.Domain.Entities;
using Hatogan.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.UseCases.Animals.Create
{
    public class CreateAnimalCommand : IRequest<IResult>
    {
        public string Number { get; private set; } = default!;
        public string? Name { get; private set; }
        public int OriginId { get; private set; }
        public int SexId { get; private set; }
        public int StatusId { get; private set; } = 1;
        public string? Color { get; private set; }
        public string? Raza { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal BirthWeight { get; private set; } = 0;
        public DateTime AdmissionDate { get; private set; }
        public decimal IncomeWeight { get; private set; } = 0;
        public decimal ActualWeight { get; private set; } = 0;
        public int? SireId { get; private set; }
        public int? DamId { get; private set; }
        public string? Remarks { get; private set; }


        internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, IResult>
        {
            private readonly IInventoryContext _context;

            public CreateAnimalCommandHandler(IInventoryContext context)
            {
                _context = context;
            }

            public async Task<IResult> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
            {
                var newAnimal = new Animal(request.Number, request.Name, request.OriginId, request.SexId, request.StatusId, request.Color, request.Raza, request.BirthDate, request.BirthWeight, request.AdmissionDate, request.IncomeWeight, request.ActualWeight, request.SireId, request.DamId, request.Remarks);

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
