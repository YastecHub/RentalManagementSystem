using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<ResponseModel<UserDto>> GetByIdAsync(int userId);

        Task<ResponseModel<UserDto>> GetByEmailAsync(string email);

        Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<ResponseModel> UpdateUser(UpdateUserDto updateUserDto, int userId);    

        Task<ResponseModel> DeleteAsync(int userId);

        Task<ResponseModel<bool>> ExistsAsync(int userId);
    }
}
