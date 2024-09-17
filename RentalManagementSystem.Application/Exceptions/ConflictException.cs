using System.Net;

namespace RentalManagementSystem.Application.Exceptions;
public class ConflictException(string message) : CustomException(message, null, HttpStatusCode.Conflict)
{
}