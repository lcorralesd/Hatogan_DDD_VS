using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.UseCases.Animals.Create
{
    public class CreateAnimalValidator : AbstractValidator<CreateAnimalCommand>
    {
        public CreateAnimalValidator()
        {
            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("Debe ingresar el valor del Código del animal")
                .MaximumLength(15).WithMessage("El Código del animal debe ser menor a 15 caracteres");
            RuleFor(a => a.Name)
                .MaximumLength(20).WithMessage("El Nombre del animal debe ser menor a 20 caracteres");
            RuleFor(a => a.Color)
                .MaximumLength(20).WithMessage("El Color del animal debe ser menor a 20 caracteres");
            RuleFor(a => a.Breed)
                .MaximumLength(20).WithMessage("La Raza del animal debe ser menor a 20 caracteres");
            RuleFor(a => a.AdmissionDate).GreaterThanOrEqualTo(a => a.BirthDate)
                .WithMessage("La fecha de ingreso debe ser mayor a la fecha de nacimiento");
            RuleFor(a => a.BirthDate).GreaterThanOrEqualTo(a => DateTime.Now.Date)
                .WithMessage("La fecha de nacimiento debe ser menor o igual a la fecha de actual");
        }
    }
}
