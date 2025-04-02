# Utilbox 🛠️

![UtilboxLogo](https://i.imgur.com/U9YNvxw.png)

Utilbox is a modular collection of C# utility libraries designed to simplify common development tasks. With separate packages for handling dates, enums, results, strings, and pagination, Utilbox helps you write cleaner, more maintainable code without reinventing the wheel.

---

### 🚀 Getting Started

#### NuGet Packages:

| Package              | Version                                                             | Downloads                                                              |
| -------------------- | ------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| `Utilbox.Dates`      | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Dates)      | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Dates)      |
| `Utilbox.Enums`      | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Enums)      | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Enums)      |
| `Utilbox.Response`   | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Response)   | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Response)   |
| `Utilbox.Result`     | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Result)     | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Result)     |
| `Utilbox.Strings`    | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Strings)    | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Strings)    |
| `Utilbox.Pagination` | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Pagination) | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Pagination) |

---

## Packages Overview

Utilbox is composed of several packages, each addressing a specific area:

### Utilbox.Dates
Provides methods and types for working with dates and date ranges.  
- **DateRange / DatetimeSpan** – Represent and manipulate date ranges.  
- **DateTimeExtensions & Utilities** – Retrieve start/end of day, week, month, and year; calculate business days; generate recurring date spans.

### Utilbox.Enums
Offers robust extensions for enum types, including:  
- Display and description retrieval via custom attributes  
- Parsing, flag manipulation, and conversion helpers

### Utilbox.Response
Provides standardized response classes for RESTful API endpoints, ensuring consistent structure and behavior across different API implementations.
- **ApiResponse<T>** – A standardized response class for API endpoints, including properties for success status, HTTP status code, data, error messages, validation errors, metadata, and timestamp.
- **OperationValidationError** – Represents a validation error for a specific field, including properties for the field name, error message, and error code.
- **PaginationMetadata** – Represents pagination metadata for API responses, including properties for total items, page size, current page, total pages, and indicators for previous and next pages.


### Utilbox.Result
Implements the [Result pattern](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-design-patterns#result-pattern) for error handling and operation outcomes.  
- **Result** and **Result<T>** – Represent successful and failed operations  
- Fluent chaining methods (e.g. `Chain`, `OnSuccess`) for composable error handling

### Utilbox.Strings
Contains string validation, conversion, and manipulation extensions.  
- **Validation** – Email, URL, ISBN, alphabetic, numeric, etc.  
- **Casing Conversions** – Title, camel, snake, and kebab case conversions  
- **General Manipulation** – Trimming, safe substring, whitespace removal, multiple replacements, reversal

### Utilbox.Pagination
Simplifies paginating collections and queryable sources.  
- **PaginatedResult<T>** – Encapsulates paged data and metadata  
- Extension methods for in-memory (`IEnumerable<T>`) and asynchronous (`IQueryable<T>`) pagination

---

## Getting Started

Utilbox is built on [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) and is compatible with any .NET implementation that supports this standard.

### Installation

You can install any of the Utilbox packages via NuGet. For example, to install Utilbox.Dates:

Using the Package Manager Console:

```powershell
Install-Package Utilbox.Dates
Install-Package Utilbox.Enums
Install-Package Utilbox.Strings
Install-Package Utilbox.Pagination
Install-Package Utilbox.Result
Install-Package Utilbox.Response
```

Using the .NET CLI:

```powershell
dotnet add package Utilbox.Dates
dotnet add package Utilbox.Enums
dotnet add package Utilbox.Strings
dotnet add package Utilbox.Pagination
dotnet add package Utilbox.Result
dotnet add package Utilbox.Response
```

## Contributing
Contributions are welcome! Please fork the repository and submit pull requests with clear descriptions of your changes. For major changes, please open an issue first to discuss what you would like to change.

## License
Utilbox is licensed under the MIT License. See LICENSE for details.

## About
Utilbox is maintained by Rafael Ferreira at RAZ Solutions. For questions, bug reports, or feature requests, please open an issue or contact me directly.
