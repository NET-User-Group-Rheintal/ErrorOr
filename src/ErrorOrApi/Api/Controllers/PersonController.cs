using Api.Contracts.Requests;
using Api.Contracts.Responses;
using Api.Mapping;
using Api.Models;
using Api.Services;
using Api.Helper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [ProducesResponseType(typeof(PersonResponse), 200)]
    [ProducesResponseType(typeof(ValidationFailureResponse), 400)]
    [HttpPost("WithoutErrorOr", Name = "WithoutErrorOr")]
    public IResult GreetPersonWithExceptions(PersonRequest request)
    {
        Person? person;
        string? message;

        try
        {
            person = request.MapToPerson();
        }
        catch
        {
            return Results.BadRequest();
        }

        try
        {
            message = _personService.GreetPersonWithException(person);
        }
        catch (ValidationException ex)
        {
            return Results.BadRequest(ValidationHelper.CreateValidationFailureResponse(ex));
        }
        catch
        {
            return Results.BadRequest();
        }

        var response = message.MapToPersonResponse();
        
        return Results.Ok(response);
    }
    
    [ProducesResponseType(typeof(PersonResponse), 200)]
    [ProducesResponseType(typeof(ValidationFailureResponse), 400)]
    [HttpPost("WithErrorOr", Name = "WithErrorOr")]
    public IResult GreetPersonWithErrorOr(PersonRequest request)
    {
        var person = request.MapToPersonWithErrorOr();

        if (person.IsError)
            return Results.BadRequest();
        
        var message = _personService.GreetPersonWithErrorOr(person.Value);
        
        if (message.IsError)
            return Results.BadRequest(ValidationHelper.CreateValidationFailureResponse(message.Errors));
        
        var response = message.Value.MapToPersonResponse();
        
        return Results.Ok(response);
    }
}
