using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Entities;
using RentalManagementSystem.Persistence.Common;
using RentalManagementSystem.Persistence.Context;
using RentalManagementSystem.Persistence.Context.Seeder;
using RentalManagementSystem.Persistence.Logging.Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure LoggerSettings
builder.Services.Configure<LoggerSettings>(builder.Configuration.GetSection(nameof(LoggerSettings)));

// Register Serilog with custom configuration
builder.RegisterSerilog();

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HTTP context accessor and current user services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Add API-related services
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Enable Swagger middleware for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentalManagementSystem API v1");
    });
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Seed roles and super admin
await app.UseItToSeedSqlServer();

// Map API controllers
app.MapControllers();

app.Run();