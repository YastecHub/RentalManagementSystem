using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<ResponseModel<UserDto>> GetByIdAsync(Guid userId);

        Task<ResponseModel<UserDto>> GetByEmailAsync(string email);

        Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<ResponseModel> UpdateUser(UpdateUserDto updateUserDto, Guid userId);    

        Task<ResponseModel> DeleteAsync(Guid userId);

        Task<ResponseModel<bool>> ExistsAsync(Guid userId);
    }
}
