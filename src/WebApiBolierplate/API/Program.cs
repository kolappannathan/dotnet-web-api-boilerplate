﻿using API.Helpers;
using API.Operations;
using Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

#region Dependency Injection

#region operations

builder.Services.AddScoped<StarupLib>();
builder.Services.AddScoped<UserLib>();
builder.Services.AddScoped<ValueLib>();

#endregion operations

#endregion Dependency Injection

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

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo {  Title="API", Version="1.0.0" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

#endregion Swagger

#endregion Configuring Services

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
