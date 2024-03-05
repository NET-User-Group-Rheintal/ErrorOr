namespace Api.Contracts.Requests;

public class PersonRequest
{
    /// <summary>
    /// First Name
    /// </summary>
    /// <example>Bill</example>
    public required string FirstName { get; init; }
    /// <summary>
    /// Last Name
    /// </summary>
    /// <example>Gates</example>
    public required string LastName { get; init; }
}