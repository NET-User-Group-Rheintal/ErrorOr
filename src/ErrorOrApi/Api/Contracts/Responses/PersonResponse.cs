namespace Api.Contracts.Responses;

public class PersonResponse
{    
    /// <summary>
    /// Message Response
    /// </summary>
    /// <example>Hello Bill Gates</example>
    public required string Message { get; init; }
}