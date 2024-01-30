using FluentValidation.Results;

namespace Products.Application.Common.Exceptions;

public class ValidationException : ApplicationException
{
    public Dictionary<string, string[]> Errors { get; set; }

    public ValidationException() : base("One or more validations failed.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        var propertyNames = failures
            .Select(f => f.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var errors = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Errors.Add(propertyName, errors);
        }
    }
}