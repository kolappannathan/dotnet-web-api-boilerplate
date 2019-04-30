using Core.Constants;
using Microsoft.Extensions.Configuration;
using System;

namespace Business.Lib.Core
{
    public class StarupLib
    {
        public StarupLib()
        {

        }

        public void LoadConfig(IConfiguration configuration)
        {
            Config.DataBase.ConnectionString = configuration["AppConfig:DataBase:ConnectionString"];
            Config.Logger.DateFormat = configuration["AppConfig:Logger:DateFormat"];
            Config.Logger.FileName = configuration["AppConfig:Logger:FileName"];
            Config.JWT.Audience = configuration["AppConfig:JWT:Audience"];
            Config.JWT.Issuer = configuration["AppConfig:JWT:Issuer"];
            Config.JWT.Key = configuration["AppConfig:JWT:Key"];
            Config.JWT.DaysValid = Convert.ToInt32(configuration["AppConfig:JWT:DaysValid"]);
        }
    }
}
