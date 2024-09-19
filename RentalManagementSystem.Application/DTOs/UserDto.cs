using RentalManagementSystem.Domain.Enums;

namespace RentalManagementSystem.Application.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public string Address { get; set; }
        public string? CustomerPhoto { get; set; }
        public Gender Gender { get; set; }
        public UserRole UserRole { get; set; }
    }

    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public string Address { get; set; }
        public string CustomerPhoto { get; set; }
        public Gender Gender { get; set; }
        public UserRole UserRole { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public string Address { get; set; }
        public string CustomerPhoto { get; set; }
        public Gender Gender { get; set; }
        public UserRole UserRole { get; set; }
    }
}
