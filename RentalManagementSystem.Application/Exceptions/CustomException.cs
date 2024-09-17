using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class CustomException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : Exception(message)
{
    public List<string>? ErrorMessages { get; } = errors;

    public HttpStatusCode StatusCode { get; } = statusCode;
}