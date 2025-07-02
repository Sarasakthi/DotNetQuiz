using ASP_NET_Quiz.Components;
using ASP_NET_Quiz.Components.Data;
using ASP_NET_Quiz.Components.Repository;
using ASP_NET_Quiz.Components.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register DbContext for Azure SQL

var connectionString = builder.Configuration.GetConnectionString("ASPNETQuiz_ConnectionString");
Console.WriteLine($"Connection String: {connectionString}");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'ASPNETQuiz_ConnectionString' is not configured.");
}

builder.Services.AddDbContext<QuizDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASPNETQuiz_ConnectionString")));

// Register Repository and Service
builder.Services.AddScoped<iQuizRepository, QuizRepository>();
builder.Services.AddScoped<iQuizService, QuizService>();

// Register Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
