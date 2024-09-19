using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Application.Abstractions.Repositories;
using RentalManagementSystem.Entities;
using RentalManagementSystem.Persistence.Context;

namespace RentalManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .Where(u => u.Id == id && !u.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email && !u.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<User> CreateUserAsync(User user, string password)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedOn = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid userId)
        {
            return await _context.Users
                .AnyAsync(u => u.Id == userId && !u.IsDeleted);
        }
    }
}
