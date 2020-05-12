# .Net core web-api boilerplate

[![GitHub License](https://img.shields.io/github/license/kolappannathan/dotnet-core-web-api-boilerplate.svg?style=flat-square)](#)
[![GitHub issues](https://img.shields.io/github/issues/kolappannathan/dotnet-core-web-api-boilerplate.svg?style=flat-square)](#)
[![GitHub contributors](https://img.shields.io/github/contributors/kolappannathan/dotnet-core-web-api-boilerplate.svg?color=orange&style=flat-square)](#)

A boilerplate / template for a WebAPI server based on ASP.Net core.

**Status**: [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/kolappannathan/dotnet-core-web-api-boilerplate/CI?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-core-web-api-boilerplate/actions?query=workflow%3ACI)

**Downloads**: [![GitHub release](https://img.shields.io/github/release/kolappannathan/dotnet-core-web-api-boilerplate.svg?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-core-web-api-boilerplate/releases)

## Scope

This API boilerplate includes the folllowing:

 - Role based JWT authentication.
 - Web API Helpers which standadizes responses, maps errors, etc...
 - An implmentation of CSV Error logger.
 - A business library and model projects for code separation.
 - A core library with the following
   - Custom data model attributes
   - Database adapter
   - Helper functions for hashing, encrypting, compression, etc...
 - A constants library for commonly used constants.

## Notice

**Before using the code in production**

###### Change the following values

 - In Config.cs in Core.Constants
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
