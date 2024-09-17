using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class InternalServerException(string message, List<string>? errors = default) : CustomException(message, errors, HttpStatusCode.InternalServerError)
{
}