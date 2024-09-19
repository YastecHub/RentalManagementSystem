using Microsoft.AspNetCore.Identity;
using RentalManagementSystem.Domain.Entities.Contracts;
using RentalManagementSystem.Domain.Enums;
using System.Collections.Generic;

namespace RentalManagementSystem.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public string Address { get; set; }
        public string? CustomerPhoto { get; set; }
        public Gender Gender { get; set; }
        public UserRole UserRole { get; set; }


        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; private set; } = DateTime.UtcNow;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
