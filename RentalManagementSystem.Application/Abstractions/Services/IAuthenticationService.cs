﻿using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<Status> LoginAsync(LoginModelDto model);

        Task LogoutAsync();

        Task<Status> ChangePasswordAsync(ChangePasswordModelDto model, string username);

        Task<string> GenerateTokenAsync(string username);
    }
}
