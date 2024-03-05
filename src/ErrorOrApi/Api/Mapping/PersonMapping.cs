using Api.Contracts.Requests;
using Api.Contracts.Responses;
using Api.Models;
using ErrorOr;

namespace Api.Mapping;

public static class PersonMapping
{
    public static Person MapToPerson(this PersonRequest request)
    {
        try
        {
            return new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    public static ErrorOr<Person> MapToPersonWithErrorOr(this PersonRequest request)
    {
        try
        {
            return new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
        }
        catch
        {
            return Error.Validation();
        }
    }

    public static PersonResponse MapToPersonResponse(this string message)
    {
        return new PersonResponse()
        {
            Message = message
        };
    }
}