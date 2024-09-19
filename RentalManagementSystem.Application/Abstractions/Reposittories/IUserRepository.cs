using RentalManagementSystem.Entities;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user, string password);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int userId);
    }
}
