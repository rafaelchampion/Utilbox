# Utilbox.Result

A robust implementation of the Result pattern for error handling and operation outcomes in .NET applications, providing a type-safe way to handle success and failure cases.

## Features

### Result and Result<T>

- Success/failure status tracking
- Type-safe error handling
- Detailed error information
- Multiple error support
- Exception preservation
- Fluent API for chaining operations

### Error Type

- Structured error representation
- Error codes and descriptions
- Error categorization
- Multiple error types support
- Common error factory methods

### Extension Methods

- Chain operations
- Transform successful results
- Handle failures
- Try-catch wrappers
- Combine multiple results

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Result
```

### .NET CLI

```bash
dotnet add package Utilbox.Result
```

## Usage Examples

### Basic Result Usage

```csharp
// Success result
var successResult = Result.Success();
var successResultWithValue = Result<User>.Success(user);

// Failure result
var failureResult = Result.Failure(Error.NotFound("UserNotFound", "User not found"));
var failureResultWithValue = Result<User>.Failure(Error.Validation("InvalidEmail", "Invalid email format"));

// Multiple errors
var errors = new List<Error>
{
    Error.Validation("InvalidEmail", "Invalid email format"),
    Error.Validation("InvalidPassword", "Password too short")
};
var multiErrorResult = Result.Failure(errors);
```

### Error Handling

```csharp
// Common error types
var notFoundError = Error.NotFound("UserNotFound", "User not found");
var validationError = Error.Validation("InvalidEmail", "Invalid email format");
var conflictError = Error.Conflict("UserExists", "User already exists");
var authError = Error.Authentication("InvalidToken", "Invalid authentication token");
var forbiddenError = Error.Authorization("NoPermission", "Insufficient permissions");
var unexpectedError = Error.Unexpected("InternalError", "An unexpected error occurred");

// Create results with specific errors
var notFoundResult = Result<User>.NotFound();
var validationResult = Result<User>.Validation();
var conflictResult = Result<User>.Conflict();
var unauthorizedResult = Result<User>.Unauthorized();
var forbiddenResult = Result<User>.Forbidden();
var unexpectedResult = Result<User>.Unexpected();
```

### Chaining Operations

```csharp
// Map successful results
var result = Result<User>.Success(user)
    .Map(u => u.Name)
    .Map(name => name.ToUpper());

// Handle success and failure
var result = Result<User>.Success(user)
    .OnSuccess(() => Console.WriteLine("User found"))
    .OnFailure(errors => Console.WriteLine($"Errors: {string.Join(", ", errors.Select(e => e.Description))}"));

// Ensure conditions
var result = Result<User>.Success(user)
    .Ensure(u => u.Email.Contains("@"), Error.Validation("InvalidEmail", "Invalid email format"))
    .Ensure(u => u.Age >= 18, Error.Validation("InvalidAge", "User must be 18 or older"));

// Try-catch wrapper
var result = Result<User>.Try(() => GetUser(id));
var resultWithHandler = Result<User>.Try(
    () => GetUser(id),
    ex => new[] { $"Error: {ex.Message}" }
);
```

### Pattern Matching

```csharp
var result = Result<User>.Success(user);

string message = result.Match(
    onSuccess: user => $"Found user: {user.Name}",
    onFailure: errors => $"Errors: {string.Join(", ", errors.Select(e => e.Description))}"
);
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
