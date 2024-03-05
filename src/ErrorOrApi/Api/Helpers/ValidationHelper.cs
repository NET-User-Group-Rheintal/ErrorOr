using Api.Contracts.Responses;
using ErrorOr;
using FluentValidation;

namespace Api.Helper;

public static class ValidationHelper
{
    public static ValidationFailureResponse CreateValidationFailureResponse(ValidationException ex)
    {
        var validationFailureResponse = new ValidationFailureResponse
        {
            Errors = ex.Errors.Select(e => new ValidationResponse
            {
                PropertyName = e.PropertyName,
                Message = e.ErrorMessage
            }).ToList()
        };
        return validationFailureResponse;
    }

    public static ValidationFailureResponse CreateValidationFailureResponse(List<Error> errors)
    {
        return new ValidationFailureResponse
        {
            Errors = errors.Select(error => new ValidationResponse
            {
                PropertyName = error.Code,
                Message = error.Description
            }).ToList()
        };
    }
}