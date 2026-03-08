using Auction.Reference.API.Extensions;
using AuctionApp.GlobalMiddleware;
using LoggerService;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSqlDb(builder.Configuration);

//// Serilog Logger Service
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File("Logger/log.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//LoggerManager log = new LoggerManager();
//log.LogInfo("Hello world");

//builder.Host.UseSerilog();

var app = builder.Build();

// Injecting Logger to application pipeline
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
