using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class ForbiddenException(string message) : CustomException(message, null, HttpStatusCode.Forbidden)
{
}