using Api.Models;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;

namespace Api.Services;

public class PersonService : IPersonService
{
    private readonly IValidator<Person> _personValidator;

    public PersonService(IValidator<Person> personValidator)
    {
        _personValidator = personValidator;
    }
    
    public string GreetPersonWithException(Person person)
    {
        _personValidator.ValidateAndThrow(person);

        return $"Hello {person.FullName}";
    }
    
    public ErrorOr<string> GreetPersonWithErrorOr(Person person)
    {
        var validationResult = _personValidator.Validate(person);

        if (validationResult.IsValid is false)
        {
            return GetValidationErrors(validationResult);
        }

        return $"Hello {person.FullName}";
    }


    private static List<Error> GetValidationErrors(ValidationResult result)
    {
        List<Error> errors = [];
        
        errors.AddRange(result.Errors.Select(error => Error.Validation(error.ErrorMessage)));

        return errors;
    }
}