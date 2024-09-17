using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class NotFoundException(string message) : CustomException(message, null, HttpStatusCode.NotFound)
{
}