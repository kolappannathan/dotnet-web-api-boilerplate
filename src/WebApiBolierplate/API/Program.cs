using API.Helpers;
using API.Operations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using Serilog;
using Serilog.Events;
using API.Operations.Interfaces;
using API.Helpers.Interfaces;
using Core.Lib.Adapters;
using Core.Lib.Utilities.Interfaces;
using Core.Lib.Utilities;
using API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// If needed, Clear default providers
builder.Logging.ClearProviders();

// Use Serilog
builder.Host.UseSerilog((hostContext, services, loggerConfig) => {
    loggerConfig
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .WriteTo.File( "Logs/api-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true);
});

// To prevent .NET and server info from being added to header if Kestrel is used
builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.AddServerHeader = false;
});

builder.Services.AddHsts(options => {
    options.Preload = true;
    options.MaxAge = TimeSpan.FromDays(30);
});

#region Configuring Services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services
    .AddProjectServices()
    .AddProjectValidations()
    .AddProjectAuthServices(builder.Configuration);

#endregion Configuring Services

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseRouting();
app.UseCors(options =>
    options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins(new[] { "https://localhost:7030/" })
);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
