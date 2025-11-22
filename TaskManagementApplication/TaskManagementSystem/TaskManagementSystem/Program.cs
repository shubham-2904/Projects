using Microsoft.Extensions.Logging;
using NLog;
using TaskManagementSystem.ActionFilter;
using TaskManagementSystem.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Adding Logger to tract the Error or info
LogManager
    .Setup()
    .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config.txt"));

// Add services to the container.
builder.Services.AddControllers();

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositaryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddScoped<ValidationFilterAttribute>();

var app = builder.Build();

// use the ConfigureExceptionHandler to log the handle the Global Exception
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.

// Configure middleware
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
