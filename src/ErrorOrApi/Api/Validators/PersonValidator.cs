using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.FirstName)
            .Length(2, 20)
            .Matches("^[a-zA-Z]*$");
        
        RuleFor(x => x.LastName)
            .Length(2, 20)
            .Matches("^[a-zA-Z]*$");
    }
}