using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Configurations;

public static class Validations
{
    public static IServiceCollection AddProjectValidations(this IServiceCollection services)
    {
        // To handle model validation errors and change it to 
        // Ref: https://stackoverflow.com/a/51159755/5407188

        var validationHelper = new ValidationHelper();

        services.Configure<ApiBehaviorOptions>(o => {
            o.InvalidModelStateResponseFactory = actionContext => validationHelper.GetDataValidationError(actionContext.ModelState);
        });

        return services;
    }
}
