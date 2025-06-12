using ASP_NET_Quiz.Components;
using ASP_NET_Quiz.Components.Data;
using ASP_NET_Quiz.Components.Repository;
using ASP_NET_Quiz.Components.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register DbContext for Azure SQL
builder.Services.AddDbContext<QuizDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuizDb")));

// Register Repository and Service
builder.Services.AddScoped<iQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
