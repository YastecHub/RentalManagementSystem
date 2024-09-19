using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                var user = new User
                {
                    FirstName = createUserDto.FirstName,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    PhoneNumber = createUserDto.PhoneNumber,
                    AlternativePhoneNumber = createUserDto.AlternativePhoneNumber,
                    Address = createUserDto.Address,
                    CustomerPhoto = createUserDto.CustomerPhoto,
                    Gender = createUserDto.Gender,
                    UserRole = createUserDto.UserRole,
                };

                var result = await _userRepository.CreateUserAsync(user, createUserDto.Password);
                if (result == null)
                    return ResponseModel<UserDto>.Failure("Failed to create user");

                var userDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    AlternativePhoneNumber = user.AlternativePhoneNumber,
                    Address = user.Address,
                    CustomerPhoto = user.CustomerPhoto,
                    Gender = user.Gender,
                    UserRole = user.UserRole
                };

                return ResponseModel<UserDto>.Success(userDto, "User created successfully");
            }
            catch (Exception ex)
            {
                return ResponseModel<UserDto>.Failure($"Error occurred while creating user");
            }
        }

        public async Task<ResponseModel> DeleteAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return new ResponseModel<UserDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "User not found"
                    };
                }

                await _userRepository.DeleteAsync(userId);
                return new ResponseModel<UserDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = $"User with {userId} deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccessful = false,
                    StatusCode = 500,
                    Message = $"Error occurred while deleting user"
                };
            }
        }

        public async Task<ResponseModel<bool>> ExistsAsync(int userId)
        {
            try
            {
                var exists = await _userRepository.ExistAsync(userId);
                return ResponseModel<bool>.Success(exists, exists ? "User exists" : "User does not exist");
            }
            catch (Exception ex)
            {
                return ResponseModel<bool>.Failure($"Error occurred while checking user existence");
            }
        }

        public async Task<ResponseModel<UserDto>> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    return new ResponseModel<UserDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "User with the Email was not found"
                    };
                }

                var userDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    AlternativePhoneNumber = user.AlternativePhoneNumber,
                    CustomerPhoto = user.CustomerPhoto,
                    Gender = user.Gender,
                    UserRole = user.UserRole
                };

                return new ResponseModel<UserDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = $"The user with {email} address retrieved successfully",
                    Data = userDto
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<UserDto>.Failure($"Error occurred while retrieving user");
            }
        }

        public async Task<ResponseModel<UserDto>> GetByIdAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return new ResponseModel<UserDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "User not found"
                    };
                }

                var userDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    AlternativePhoneNumber = user.AlternativePhoneNumber,
                    Address = user.Address,
                    CustomerPhoto = user.CustomerPhoto,
                    Gender = user.Gender,
                    UserRole = user.UserRole
                };

                return new ResponseModel<UserDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = $"User with {userId} retrieved successfully",
                    Data = userDto
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<UserDto>.Failure($"Error occurred while retrieving user");
            }
        }

        public async Task<ResponseModel> UpdateUser(UpdateUserDto updateUserDto, int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "User not found"
                    };
                }

                user.FirstName = updateUserDto.FirstName;
                user.LastName = updateUserDto.LastName;
                user.Email = updateUserDto.Email;
                user.PhoneNumber = updateUserDto.PhoneNumber;
                user.AlternativePhoneNumber = updateUserDto.AlternativePhoneNumber;
                user.Address = updateUserDto.Address;
                user.CustomerPhoto = updateUserDto.CustomerPhoto;
                user.Gender = updateUserDto.Gender;
                user.UserRole = updateUserDto.UserRole;

                await _userRepository.UpdateAsync(user);

                return new ResponseModel<UserDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "User updated successfully",
                    Data = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        AlternativePhoneNumber = user.AlternativePhoneNumber,
                        Address = user.Address,
                        CustomerPhoto = user.CustomerPhoto,
                        Gender = user.Gender,
                        UserRole = user.UserRole
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccessful = false,
                    StatusCode = 500,
                    Message = "Error occurred while updating user"
                };
            }
        }
    }
}
