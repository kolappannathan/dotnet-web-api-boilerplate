using API.Helpers;
using Business.Lib.Core;
using Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// To prevent .NET and server info from being added to header if Kestrel is used
builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.AddServerHeader = false;
});

#region Configuring Services

var startupLib = new StarupLib();
startupLib.LoadConfig(builder.Configuration);

builder.Services.AddControllers();

#region [Validation Handling]

// To handle model validation errors and change it to 
// Ref: https://stackoverflow.com/a/51159755/5407188

var validationHelper = new ValidationHelper();

builder.Services.Configure<ApiBehaviorOptions>(o => {
    o.InvalidModelStateResponseFactory = actionContext => validationHelper.GetDataValidationError(actionContext.ModelState);
});

#endregion [Validation Handling]

#region [Authentication]

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Config.JWT.Issuer,
            ValidAudience = Config.JWT.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.JWT.Key))
        };
    });

#endregion [Authentication]

#endregion Configuring Services

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
