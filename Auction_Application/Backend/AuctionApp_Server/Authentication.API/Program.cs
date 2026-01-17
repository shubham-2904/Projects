using Authentication.API.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Injecting Extension Services
builder.Configuration.AddUtiliesConfigJson();
builder.Services.AddUtilityRegistration();
builder.Services.AddSqlDb(builder.Configuration);
builder.Services.AddAuthenticationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();