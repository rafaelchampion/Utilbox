# Utilbox.Response

A standardized response library for building consistent RESTful APIs in .NET applications, providing a unified way to handle API responses, validation errors, and pagination metadata.

## Features

### ApiResponse<T>

- Standardized response structure with:
  - Success/failure status
  - HTTP status code
  - Generic data payload
  - Error message
  - Validation errors
  - Custom metadata
  - Timestamp
  - Request ID
- Factory methods for common scenarios:
  - Success responses
  - Error responses
  - Validation error responses
- Metadata management:
  - Add custom metadata
  - Add pagination metadata
- JSON serialization support

### OperationValidationError

- Field-level validation error representation
- Error message and code support
- Multiple validation errors handling
- Custom validation error types

### PaginationMetadata

- Total items count
- Page size configuration
- Current page tracking
- Total pages calculation
- Previous/next page indicators

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Response
```

### .NET CLI

```bash
dotnet add package Utilbox.Response
```

## Usage Examples

### Basic API Response

```csharp
// Success response
var successResponse = ApiResponse<User>.CreateSuccess(
    data: user,
    statusCode: HttpStatusCode.OK,
    requestId: "req-123"
);

// Error response
var errorResponse = ApiResponse<User>.CreateError(
    errorMessage: "User not found",
    statusCode: HttpStatusCode.NotFound,
    requestId: "req-123"
);

// Validation error response
var validationErrors = new List<OperationValidationError>
{
    new("Email", "Invalid email format", "INVALID_EMAIL"),
    new("Password", "Password too short", "PASSWORD_TOO_SHORT")
};

var validationResponse = ApiResponse<User>.CreateValidationError(
    validationErrors: validationErrors,
    errorMessage: "Validation failed",
    statusCode: HttpStatusCode.BadRequest,
    requestId: "req-123"
);
```

### Adding Metadata

```csharp
// Add custom metadata
var response = ApiResponse<User>.CreateSuccess(user)
    .AddMetadata("ProcessingTime", 150)
    .AddMetadata("ServerName", "API-01");

// Add pagination metadata
var response = ApiResponse<List<User>>.CreateSuccess(users)
    .AddPaginationMetadata(
        totalItems: 100,
        pageSize: 10,
        currentPage: 1,
        totalPages: 10
    );
```

### Using PaginationMetadata

```csharp
var metadata = new PaginationMetadata
{
    TotalItems = 100,
    PageSize = 10,
    CurrentPage = 1,
    TotalPages = 10
};

// Check navigation
bool hasNext = metadata.HasNext;     // true
bool hasPrevious = metadata.HasPrevious; // false
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
