using Api.Models;
using ErrorOr;

namespace Api.Services;

public interface IPersonService
{
    string GreetPersonWithException(Person person);
    ErrorOr<string> GreetPersonWithErrorOr(Person person);
}