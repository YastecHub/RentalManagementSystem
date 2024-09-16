using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(string userId);

        Task<User> GetByEmailAsync(string email);

        Task<User> CreateUserAsync(User user, string password);

        Task UpdateAsync(User user);    

        Task DeleteAsync(string userId);

        Task<bool> ExistsAsync(string userId);
    }
}
