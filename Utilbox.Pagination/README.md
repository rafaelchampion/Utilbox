# Utilbox.Pagination

A lightweight and efficient pagination library for .NET applications that provides a simple way to paginate collections and handle paginated results.

## Features

### PaginatedResult<T>

- Immutable result type with read-only collections
- Comprehensive pagination metadata:
  - Current page number (1-based)
  - Page size
  - Total items count
  - Total pages count
  - Next/previous page indicators
- Type-safe generic implementation

### Pagination Utilities

- In-memory collection pagination
- Input validation for page numbers and sizes
- Efficient skip/take operations
- Automatic total pages calculation

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Pagination
```

### .NET CLI

```bash
dotnet add package Utilbox.Pagination
```

## Usage Examples

### Basic Pagination

```csharp
// Create a collection
var items = Enumerable.Range(1, 100).ToList();

// Paginate the collection
var pageNumber = 1u;  // First page
var pageSize = 10u;   // 10 items per page
var paginatedResult = items.ToPaginatedResult(pageNumber, pageSize);

// Access pagination metadata
Console.WriteLine($"Page {paginatedResult.PageNumber} of {paginatedResult.TotalPages}");
Console.WriteLine($"Showing {paginatedResult.Items.Count} of {paginatedResult.TotalItems} items");
Console.WriteLine($"Has next page: {paginatedResult.HasNextPage}");
Console.WriteLine($"Has previous page: {paginatedResult.HasPreviousPage}");

// Access the items
foreach (var item in paginatedResult.Items)
{
    Console.WriteLine(item);
}
```

### Working with Paginated Results

```csharp
// Create a paginated result manually
var items = new List<string> { "Item1", "Item2", "Item3" };
var result = new PaginatedResult<string>(
    items: items,
    pageNumber: 1,
    pageSize: 10,
    totalItems: 3,
    totalPages: 1
);

// Access properties
var currentPage = result.PageNumber;
var itemsPerPage = result.PageSize;
var totalItems = result.TotalItems;
var totalPages = result.TotalPages;
var hasNext = result.HasNextPage;
var hasPrevious = result.HasPreviousPage;
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
