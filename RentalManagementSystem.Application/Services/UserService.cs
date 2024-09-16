//using RentalManagementSystem.Application.Abstractions.Reposittories;
//using RentalManagementSystem.Application.Abstractions.Services;
//using RentalManagementSystem.Application.DTOs;
//using RentalManagementSystem.Application.DTOs.RentalManagementSystem.Application.DTOs;
//using RentalManagementSystem.Entities;

//namespace RentalManagementSystem.Application.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }
//        public async Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
//        {
//            var user = new User
//            {
//                FirstName = createUserDto.FirstName,
//                LastName = createUserDto.LastName,
//                Email = createUserDto.Email,
//                PhoneNumber = createUserDto.PhoneNumber,
//                AlternativePhoneNumber = createUserDto.AlternativePhoneNumber,
//                Address = createUserDto.Address,
//                CustomerPhoto = createUserDto.CustomerPhoto,
//                Gender = createUserDto.Gender,
//                UserRole = createUserDto.UserRole,
//            };

//            var result = await _userRepository.CreateUserAsync(user,createUserDto.Password);
//            if (!result)
//                return ResponseModel<UserDto>.Failure("Failed to craete User");

//            var userDto = new UserDto
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber,
//                AlternativePhoneNumber = user.AlternativePhoneNumber,
//                Address = user.Address,
//                CustomerPhoto = user.CustomerPhoto,
//                Gender = user.Gender,
//                UserRole = user.UserRole
//            };
//            return ResponseModel<UserDto>.Success(userDto);
//        }

//        public Task<ResponseModel> DeleteAsync(string userId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ResponseModel<bool>> ExistsAsync(string userId)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ResponseModel<UserDto>> GetByEmailAsync(string email)
//        {
//            var user = await _userRepository.GetUserByEmail(email);
//            if (user == null)
//            {
//                return ResponseModel<UserDto>.Failure("User not found");
//            }

//            var userDto = new UserDto
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber,
//                Address = user.Address,
//                AlternativePhoneNumber = user.AlternativePhoneNumber,
//                CustomerPhoto = user.CustomerPhoto,
//                Gender = user.Gender,
//                UserRole = user.UserRole
//            };

//            return ResponseModel<UserDto>.Success(userDto);
//        }

//        public async Task<ResponseModel<UserDto>> GetByIdAsync(string userId)
//        {
//            var user = await _userRepository.GetUserByIdAsync(userId);
//            if (user == null)
//            {
//                return ResponseModel<UserDto>.Failure("User not found");
//            }

//            var userDto = new UserDto
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber,
//                AlternativePhoneNumber = user.AlternativePhoneNumber,
//                Address = user.Address,
//                CustomerPhoto = user.CustomerPhoto,
//                Gender = user.Gender,
//                UserRole = user.UserRole
//            };

//            return ResponseModel<UserDto>.Success(userDto);
//        }

//        public Task<ResponseModel> UpdateAsync(UpdateUserDto updateUserDto, string userId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
