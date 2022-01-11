using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.Exceptions
{
    public class ApiValidationException : Exception
    {
        public ApiValidationException() : base("Se han producido uno o más errores de validación")
        {
        }

        public List<string> Errors { get; } = new List<string>();

        public ApiValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
