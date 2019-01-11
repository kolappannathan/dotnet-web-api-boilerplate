using API.Helpers;
using Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region [Assign Config]

            Config.DataBase.ConnectionString = Configuration["AppConfig:DataBase:ConnectionString"];
            Config.Logger.DateFormat = Configuration["AppConfig:Logger:DateFormat"];
            Config.Logger.FileName = Configuration["AppConfig:Logger:FileName"];
            Config.JWT.Audience = Configuration["AppConfig:JWT:Audience"];
            Config.JWT.Issuer = Configuration["AppConfig:JWT:Issuer"];
            Config.JWT.Key = Configuration["AppConfig:JWT:Key"];

            #endregion [Assign Config]
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region [Validation Handling]

            // To handle model validation errors and change it to 
            // Ref: https://stackoverflow.com/a/51159755/5407188

            var validationHelper = new ValidationHelper();

            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext => validationHelper.GetDataValidationError(actionContext.ModelState);
            });

            #endregion [Validation Handling]

            #region [Authentication]

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
