using FluentValidation.Results;

namespace SubstationTracker.Application.Utilities.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationFailure> validationFailures)
    {
        foreach (var validationFailure in validationFailures)
            ValidationErrors.Add(new KeyValuePair<string, string>(validationFailure.PropertyName,
                validationFailure.ErrorMessage));
    }

    public List<KeyValuePair<string, string>> ValidationErrors { get; set; } = new();
}