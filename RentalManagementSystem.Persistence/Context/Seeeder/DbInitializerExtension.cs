using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Persistence.Context.Seeder
{
    public static class DbInitializerExtension
    {
        public static async Task<IApplicationBuilder> UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                // Use IdentityRole<Guid> since your roles are based on Guid
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                await ContextSeeder.SeedRolesAsync(roleManager);
                await ContextSeeder.SeedAdminAsync(userManager);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while seeding the database.", ex);
            }

            return app;
        }
    }
}
