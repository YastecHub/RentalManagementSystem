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

builder.Services.AddControllersWithViews();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ensure authentication and authorization middleware are configured
app.UseAuthentication();
app.UseAuthorization();

// Seed roles and super admin (ensure this method is correct)
await app.UseItToSeedSqlServer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
