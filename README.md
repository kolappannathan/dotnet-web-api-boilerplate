# .Net core web-api boilerplate

[![GitHub License](https://img.shields.io/github/license/kolappannathan/dotnet-core-web-api-boilerplate.svg?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-core-web-api-boilerplate/blob/master/LICENSE)
[![GitHub release](https://img.shields.io/github/release/kolappannathan/dotnet-core-web-api-boilerplate.svg?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-core-web-api-boilerplate/releases)
[![Build Status](https://img.shields.io/azure-devops/build/kolappannathan/DotNetCore_Web_API_Boilerplate/4/master.svg?style=flat-square&logo=azure%20pipelines&label=Build%3A%20Azure%20pipelines)](https://dev.azure.com/kolappannathan/DotNetCore_Web_API_Boilerplate/_build/latest?definitionId=4&branchName=master)

A boilerplate / template for a WebAPI server based on ASP.Net core.

### Scope

This API boilerplate includes the folllowing:

 1. Role based JWT authentication.
 2. Web API Helpers which standadizes responses, maps errors, etc...
 3. An implmentation of CSV Error logger.
 4. A business library and model projects for code separation.
 5. A core library with helper functions.
 6. A constants library for commonly used constants.

## Notice

**Before using the code in production**

###### Change the following values

 - In Config.cs in Core.Lib
    1. Security.EncryptionKey
 - In appsettings.json
    1. Database connection string.
       - This string should be in ecrypted format. **Encrypted with the new encryption key**.
    2. JWT secret, issuer and audience
 - In launchsettings.json,
    1. Change SSL port
    2. Change applicationURL
 - In Base class in BusinessLib, uncomment the line that establishes db connection

###### Remove the following code
 - HelpersLib in BusineesLib
 - HelpersController in API
