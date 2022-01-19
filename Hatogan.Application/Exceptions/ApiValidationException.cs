using FluentValidation.Results;

namespace Hatogan.Application.Exceptions;

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
