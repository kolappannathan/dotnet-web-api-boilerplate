# .Net Web API boilerplate

[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/kolappannathan/dotnet-web-api-boilerplate/CI?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-web-api-boilerplate/actions?query=workflow%3ACI)
[![GitHub release](https://img.shields.io/github/release/kolappannathan/dotnet-web-api-boilerplate.svg?logo=github&style=flat-square)](https://github.com/kolappannathan/dotnet-web-api-boilerplate/releases)

A boilerplate / template for a WebAPI server based on ASP.Net.

## Scope

This API boilerplate includes the following:

 - Role based JWT authentication.
 - Web API Helpers which standardizes responses, maps errors, etc...
 - An implementation of CSV Error logger.
 - A business library and model projects for code separation.
 - A core library with the following
   - Custom data model attributes
   - Database adapter
   - Helper functions for hashing, encrypting, compression, random number & character generation, etc...
 - A constants library for commonly used constants.

## Notice

**Before using the code in production**

###### Change the following values

 - In Config.cs in Core.Constants
    1. Security.EncryptionKey
 - In appsettings.json
    1. Database connection string.
    2. JWT secret, issuer and audience
 - In launchsettings.json,
    1. Change SSL port
    2. Change applicationURL
 - In Base class in BusinessLib, uncomment the line that establishes db connection
 - This project has a default editorconfig file. If needed customize it.
