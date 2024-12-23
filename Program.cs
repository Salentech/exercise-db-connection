using System.Reflection;
using System.Text.Json;
using exercise_db_connection.Data;
using exercise_db_connection.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);


// Add Configurations
builder.Configuration.AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);


// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure(3));
});

// Add Authentication
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftAccount(options =>
        {
            options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? "error";
            options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? "error";
        })
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));


// Add services
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<ReviewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();