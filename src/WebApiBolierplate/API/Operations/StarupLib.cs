using Core.Constants;
using Microsoft.Extensions.Configuration;
using System;

namespace API.Operations;

public class StarupLib
{
    public StarupLib()
    {

    }

    public void LoadConfig(IConfiguration configuration)
    {
        Config.Logger.DateFormat = configuration["AppConfig:Logger:DateFormat"];
        Config.Logger.FileName = configuration["AppConfig:Logger:FileName"];
        Config.Logger.RelativePath = configuration["AppConfig:Logger:RelativePath"];
        Config.Logger.ReplacementValue = configuration["AppConfig:Logger:ReplacementValue"][0];
    }
}
