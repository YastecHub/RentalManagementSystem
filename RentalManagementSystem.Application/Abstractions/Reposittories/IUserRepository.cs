using RentalManagementSystem.Entities;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user, string password);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid userId);
    }
}
