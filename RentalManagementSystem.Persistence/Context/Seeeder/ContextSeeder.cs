using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using Microsoft.AspNetCore.Identity;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Persistence.Context.Seeder
{
    public static class ContextSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RoleConstants.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
            }

            if (!await roleManager.RoleExistsAsync(RoleConstants.Customer))
            {
                await roleManager.CreateAsync(new IdentityRole(RoleConstants.Customer));
            }
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {
            var defaultUser = new User
            {
                UserName = "Yastec",
                Email = "yasiroyebo@gmail.com",
                PhoneNumber = "09068913009",
                AlternativePhoneNumber = "09068913009",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedBy = "System",
                Gender = Gender.Male,
                LastModifiedBy = "System"
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "Admin@12345#.");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, RoleConstants.Admin);
                    await userManager.AddToRoleAsync(defaultUser, RoleConstants.Customer);
                }
            }
        }
    }
}
