# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Added
 - Additional logger config in app settings

### Changed
 - StartupLib now refers to helpers functions in core lib instead of business lib.
 - Updating dependencies
 - Moved logger config assignment directly to logger

## [3.4.0] - 2019-05-20
### Changed
 - Updated to .Net core 2.2

## [3.3.0] - 2019-05-16
### Added
 - New appconfig for developement and production

### Changed
 - Reorganised postman request in the order they appear in code.
 - Updated nuget packages


## [3.2.0] - 2019-05-09
### Added
 - Documentation for encryption helper

### Changed
 - Renamed CSV Logger
 - Optimised code in helpersLib

## [3.1.0] - 2019-05-08
### Changed
 - Added sub classes to helper
 - Moved Enums to constatnts
 - Minor code optimizations

## [3.0.0] - 2019-05-07
### Added
 - New function for encrypting and decrypting strings
 - New APIs to test Helper library functions

### Changed
 - Role claim in JWT chnaged to fix a bug
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
- Added documentaion for many functions and classes
- New claims for JWT token

### Changed
- Updated NuGet package
- Replace induvidual claim adding code using a common function

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
- Constants are now added in statup.cs.
- Other minor code optimizations.

## [0.0.1] - 2019-01-02
### Added
- Added changelog.
- Added core library.
- Added API Helper functions.

### Changed
- Format of model validation errors.