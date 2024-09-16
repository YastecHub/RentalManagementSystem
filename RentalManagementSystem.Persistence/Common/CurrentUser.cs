using Microsoft.AspNetCore.Http;
using RentalManagementSystem.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RentalManagementSystem.Persistence.Common
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string? FullName => $"{_httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName)} {_httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname)}";

        public IEnumerable<Claim>? GetUserClaims() => _httpContextAccessor?.HttpContext?.User?.Claims;

        public string? GetUserEmail() =>
            IsAuthenticated() ? _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) : null;

        public string? GetUserPhoneNumber() =>
            IsAuthenticated() ? _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone) : null;

        public Guid GetUserId()
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!IsAuthenticated() || string.IsNullOrEmpty(userId))
            {
                return Guid.Empty;
            }

            return Guid.TryParse(userId, out var guid) ? guid : Guid.Empty;
        }

        public bool IsAuthenticated() =>
            _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
