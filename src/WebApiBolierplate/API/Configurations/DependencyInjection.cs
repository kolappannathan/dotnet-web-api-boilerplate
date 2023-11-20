using API.Helpers.Interfaces;
using API.Helpers;
using API.Operations.Interfaces;
using API.Operations;
using Core.Lib.Utilities.Interfaces;
using Core.Lib.Utilities;

namespace API.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        #region operations

        services.AddScoped<IUserLib, UserLib>();
        services.AddScoped<IValueLib, ValueLib>();
        services.AddScoped<IAuthLib, AuthLib>();

        #endregion operations

        services.AddScoped<IJwtUtils, JwtUtils>();
        services.AddScoped<IWebAPIHelper, WebAPIHelper>();

        return services;
    }
}
