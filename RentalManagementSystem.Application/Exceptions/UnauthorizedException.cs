using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class UnauthorizedException(string message) : CustomException(message, null, HttpStatusCode.Unauthorized)
{
}