using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Abstractions.Reposittories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string id);

        Task<User> GetUserByEmail(string email);

        Task<User> CreateUserAsync(User user, string password);

        Task UpdateAsync(User user);

        Task DeleteAsync(string id);

        Task<bool> ExistAsync(string userId);
    }
}
