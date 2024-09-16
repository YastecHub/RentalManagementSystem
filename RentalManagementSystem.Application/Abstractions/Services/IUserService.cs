using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Application.DTOs.RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<ResponseModel<UserDto>> GetByIdAsync(string userId);

        Task<ResponseModel<UserDto>> GetByEmailAsync(string email);

        Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<ResponseModel> UpdateAsync(UpdateUserDto updateUserDto, string userId);    

        Task<ResponseModel> DeleteAsync(string userId);

        Task<ResponseModel<bool>> ExistsAsync(string userId);
    }
}
