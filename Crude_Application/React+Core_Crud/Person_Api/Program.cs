using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Person_Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup()
    .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
                               "/nlog.config.txt"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigurExecptionHandler(logger);
app.UseCors("CorsPolicy");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthorization();

app.MapControllers();

app.Run();
