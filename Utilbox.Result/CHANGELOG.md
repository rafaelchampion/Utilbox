# Changelog

All notable changes to the Utilbox.Result project will be documented in this file.

## [2.1.0] - 2024-04-04

### Breaking Changes

- Changed error representation from string-based to structured `Error` type
  - Removed string-based error constructors
  - Introduced new `Error` class with `Code`, `Description`, and `Type` properties
  - Added `ErrorType` enum for standardized error categorization
- Deprecated string-based error methods:
  - `Result.Failure(string errorDescription)`
  - `Result.Failure(IEnumerable<string> errorDescriptions)`
  - `Result<T>.Failure(string errorDescription)`
  - `Result<T>.Failure(IEnumerable<string> errorDescriptions)`

### Added

- New `Error` class for structured error representation
- `ErrorType` enum for standardized error categorization
- Factory methods for common error types:
  - `Error.Validation()`
  - `Error.NotFound()`
  - `Error.Conflict()`
  - `Error.Authentication()`
  - `Error.Authorization()`
  - `Error.Unexpected()`
  - `Error.Generic()`
- Enhanced error handling with multiple error support
- New extension methods for chaining operations:
  - `Chain<TIn, TOut>()`
  - `ChainAsync<TIn, TOut>()`
  - `OnSuccess<TIn, TOut>()`
  - `OnSuccessAsync<TIn, TOut>()`

### Changed

- Improved error handling with type-safe error representation
- Enhanced documentation with XML comments
- Updated package dependencies
- Improved pipeline integration

## [2.0.0] - 2024-12-03

### Added

- Initial release of Utilbox.Result package
- Basic Result pattern implementation
- Support for success/failure states
- Basic error handling with string messages
- Extension methods for basic operations
- XML documentation
- Unit tests
- README with usage examples

### Changed

- Project structure and organization
- Package metadata and documentation

## [1.0.0] - 2024-12-03

### Added

- Initial project setup
- Basic project structure
- Core Result pattern implementation
- Basic error handling
- Documentation
