using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface ICurrentUser
    {
        string? FullName { get; }
        Guid GetUserId();
        string? GetUserEmail();
        bool IsAuthenticated();
        string? GetUserPhoneNumber();
        IEnumerable<Claim>? GetUserClaims();
    }
}
