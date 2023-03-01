# Changelog
All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [Unreleased]

## [7.1.0] - 2023-03-02
### Added
 - Added interfaces for library classes, helper functions.
 - New AuthLib class for checking login and generating token.

### Changed
 - Helper functions now use dependency injection.
 - Made all non-derived classes sealed for security and performance.
 - Optimizations to JWT helpers, moved JWT token builder in core project.
 - Private variables now start with underscore.
 - JWT config now has Hours valid instead of days.

### Removed
 - Base class for operations is removed
 - Removed unused constants
 - Removed JWT Helper function from API project

## [7.0.0] - 2023-02-27
### Added
 - CORS settings

### Changed
 - Updated .NET version to 7
 - Using Serilog.AspNetCore for logging instead of serilog extensions as recommended by Serilog
 - Log files are now separated by date
 - Using new syntax for Argument null checks
 - Updated dependencies

## [6.1.0] - 2022-08-15
### Added
 - Added dependency Injection
 - Added Serilog

### Changed
 - Updated the default port
 - Updated API Helper
 - Encryption key is no longer part of code
 - Consolidated Business & Models into API project
 - Random Number generation now uses RandomNumberGenerator instead of RNGCryptoServiceProvider

### Removed
 - Removed config static class
 - Removed StartupLib and Tasks Controller
 - Removed csv logger

## [6.0.0] - 2022-07-16
### Added
 - Added Swagger UI

### Changed
 - Updated .NET to version 6
 - Unified Program.cs & startup.cs
 - Removing code intent for namespaces
 - Bad Request now return isError as true in addition to the HTTP status code
 - Postman now updated bearer token automatically after a successful login API call
 - Updated dependencies to latest versions

## [5.1.0] - 2021-09-19
### Added
 - Added unit testing for Helper functions. Removed the APIs used for manually testing them.
 - Added editor config

### Changes
 - Removed server headers for security
 - Connection string in appsettings.json is no longer encrypted. Ref [#74](https://github.com/kolappannathan/dotnet-web-api-boilerplate/issues/74) for details

## [5.0.0] - 2021-05-23
### Changed
 - Updated .Net to version 5
 - Updated packages
 - Moved CI from Azure DevOps to GitHub Actions
 - Moved postman collection into the src folder

## [4.1.0] - 2020-05-08
### Changed
 - Updating API to .Net core 3.1
 - Updating Libraries to .Net standard 2.1
 - Updating dependencies
 - Fixing some local and package references
 - JWT key is now stored as variable in postman collection
 - Minor code optimizations such as making some variables read only, using range operator, etc...

## [4.0.0] - 2019-09-20
### Added
 - Additional logger config in app settings
 - New helper function to remove line endings
 - New helper function that combines date and time from two different Date objects
 - New Date attributes for PastOnly and PastAndPresent

### Changed
 - StartupLib now refers to helpers functions in core lib instead of business lib.
 - Updating dependencies
 - Moved logger config assignment directly to logger
 - Renaming and relocating new Date attributes

## [3.4.0] - 2019-05-20
### Changed
 - Updated to .Net core 2.2

## [3.3.0] - 2019-05-16
### Added
 - New appconfig for development and production

### Changed
 - Reorganised postman request in the order they appear in code.
 - Updated NuGet packages


## [3.2.0] - 2019-05-09
### Added
 - Documentation for encryption helper

### Changed
 - Renamed CSV Logger
 - Optimised code in helpersLib

## [3.1.0] - 2019-05-08
### Changed
 - Added sub classes to helper
 - Moved Enums to constants
 - Minor code optimizations

## [3.0.0] - 2019-05-07
### Added
 - New function for encrypting and decrypting strings
 - New APIs to test Helper library functions

### Changed
 - Role claim in JWT changed to fix a bug
 - Optimized code in JWT token builder
 - Database connection string in appconfig is now encrypted

## [2.0.1] - 2019-05-03
### Added
 - New custom claims

### Changed
 - Code optimisations in JWT token builder
 - Few bug fixes in JWT token


## [2.0.0] - 2019-04-30
### Added
 - New startup lib for operations performed during startup
 - New API that reassigns config on the fly
 - New class for info texts

### Changed
 - JWT token validity is now taken from config
 - Moved Base class in business lib into Core namespace
 - Converted Logger functions into expressions

## [1.0.1] - 2019-03-25
### Added
- Added documentation for many functions and classes
- New claims for JWT token

### Changed
- Updated NuGet package
- Replace individual claim adding code using a common function

## [1.0.0] - 2019-01-11
### Added
- Added JWT authorization.
- Added new library function for Value controller.
- Added model validation.

### Changed
- All responses now use APIResponse model.
- Updated Postman file with value controller and description.
- Moved all config to appsettings.json

## [0.0.2] - 2019-01-10
### Added
- Completed JWT token generation.
- Created business library.
- Added postman collection file.

### Changed
- Removed Tuple declarations.
- Constants are now added in startup.cs.
- Other minor code optimizations.

## [0.0.1] - 2019-01-02
### Added
- Added changelog.
- Added core library.
- Added API Helper functions.

### Changed
- Format of model validation errors.