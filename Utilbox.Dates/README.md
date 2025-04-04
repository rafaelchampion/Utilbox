# Utilbox.Dates

A comprehensive date and time utility library for .NET applications that provides powerful date range manipulation, business day calculations, and common date/time operations.

## Features

### DateRange

- Represents a range of dates with start and end dates
- Validation to ensure start date is before end date
- Immutable struct design for thread safety

### DateRange Extensions

- Overlap detection between date ranges
- Intersection calculation
- Duration and period calculations (days, weeks, months, years)
- Date range enumeration (days, months)
- Range extension capabilities

### DateTime Extensions

- Week addition operations
- Holiday detection
- Weekend checking

### DateTime Utilities

- Period boundary calculations (start/end of day, week, month, year)
- Business day operations:
  - Next/previous business day
  - Business days between dates
  - Nearest workday
  - Workdays in period
- Age calculations:
  - Exact age in TimeSpan
  - Age in years with optional reference date

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Dates
```

### .NET CLI

```bash
dotnet add package Utilbox.Dates
```

## Usage Examples

### DateRange Operations

```csharp
// Create a date range
var range = new DateRange(startDate, endDate);

// Check for overlap
bool hasOverlap = range1.Overlaps(range2);

// Get intersection
var intersection = range1.GetIntersection(range2);

// Calculate duration
TimeSpan duration = range.GetDuration();
int days = range.GetDays();
int weeks = range.GetWeeks();
int months = range.GetMonths();
int years = range.GetYears();

// Enumerate dates
foreach (var date in range.EnumerateDays())
{
    // Process each day
}

// Enumerate months
foreach (var monthRange in range.EnumerateMonths())
{
    // Process each month
}
```

### DateTime Extensions

```csharp
// Add weeks
DateTime futureDate = dateTime.AddWeeks(2);

// Check for holidays
bool isHoliday = dateTime.IsHoliday(holidayList);

// Check for weekend
bool isWeekend = dateTime.IsWeekend();
```

### DateTime Utilities

```csharp
// Period boundaries
DateTime startOfDay = DateTimeUtilities.GetStartOfDay(dateTime);
DateTime endOfMonth = DateTimeUtilities.GetEndOfMonth(dateTime);

// Business day operations
DateTime nextBusinessDay = DateTimeUtilities.GetNextBusinessDay(dateTime);
int businessDays = DateTimeUtilities.GetBusinessDaysBetween(startDate, endDate);

// Age calculations
int age = DateTimeUtilities.GetAge(birthDate);
TimeSpan exactAge = DateTimeUtilities.GetExactAge(birthDate);
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
