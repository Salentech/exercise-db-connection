using System.Reflection;
using System.Text.Json;
using exercise_db_connection.Data;
using exercise_db_connection.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

#region Configuration Setup
// Add configuration sources:
// - User secrets: for secure development storage of sensitive data
// - Environment variables: for runtime configuration in different environments
// - Additional JSON configuration: optional file for secrets or overrides
builder.Configuration.AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

// Debugging: Print the AzureAd configuration section to the console
var azureAdConfig = builder.Configuration.GetSection("AzureAd");
Console.WriteLine("AzureAd Configuration:");
Console.WriteLine(JsonSerializer.Serialize(azureAdConfig));
#endregion

#region Services Registration

// Register MVC controllers with support for Microsoft Identity UI
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

// Register AutoMapper to simplify object mapping
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Register Entity Framework DbContext with retry logic on transient failures
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure(3));
});

// Configure authentication using Microsoft Identity and Azure AD
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

// Register application repositories for dependency injection
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<ReviewRepository>();

#endregion

var app = builder.Build();

#region Middleware Configuration

// Configure middleware for error handling and HSTS in production environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforces strict transport security
}

// Enforce HTTPS redirection and serve static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure request routing
app.UseRouting();

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

// Start the application
app.Run();
