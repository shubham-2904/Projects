using Auction.Reference.API.Extensions;
using AuctionApp.GlobalMiddleware;
using LoggerService;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog Logger Service
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSqlDb(builder.Configuration);
builder.Services.AddLoggerManager();
builder.Services.AddRepositoryManager();
builder.Services.AddServiceManager();

//builder.Host.UseSerilog();

var app = builder.Build();

//// Injecting Logger to application pipeline
//app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
