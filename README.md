# Utilbox 🛠️

![UtilboxLogo](https://github.com/user-attachments/assets/264e82b1-f31d-4760-8de9-a6bb1fa1b492)

**Utilbox** is a collection of utility libraries designed to make development easier, faster, and more efficient for C# developers. With a focus on flexibility and performance, Utilbox offers a wide range of tools, from date and enum manipulation to the powerful Result pattern implementation.

---

### 🚀 Getting Started

#### NuGet Packages:

| Package              | Version                                                             | Downloads                                                              |
| -------------------- | ------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| `Utilbox.Dates`      | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Dates)      | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Dates)      |
| `Utilbox.Enums`      | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Enums)      | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Enums)      |
| `Utilbox.Result`     | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Result)     | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Result)     |
| `Utilbox.Strings`    | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Strings)    | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Strings)    |
| `Utilbox.Pagination` | ![NuGet Version](https://img.shields.io/nuget/v/Utilbox.Pagination) | ![NuGet Downloads](https://img.shields.io/nuget/dt/Utilbox.Pagination) |

You can install any of these packages directly from NuGet:

```
Install-Package Utilbox.Dates
Install-Package Utilbox.Enum
Install-Package Utilbox.Result
Install-Package Utilbox.Strings
Install-Package Utilbox.Pagination
```

Or by using the .NET CLI:

```
dotnet add package Utilbox.Dates
dotnet add package Utilbox.Enum
dotnet add package Utilbox.Result
dotnet add package Utilbox.Strings
dotnet add package Utilbox.Pagination
```

---

### 📚 Documentation

### Utilbox.Dates

`DatetimeSpan()`: Initializes a new instance of the DatetimeSpan struct.

#### DatetimeSpanHelper

`CurrentDay()`: Gets the DatetimeSpan for the current day.

`NextDay()`: Gets the DatetimeSpan for the next day.

`PreviousDay()`: Gets the DatetimeSpan for the previous day.

`CurrentWeek()`: Gets the DatetimeSpan for the current week.

`CurrentMonth()`: Gets the DatetimeSpan for the current month.

`NextMonth()`: Gets the DatetimeSpan for the next month.

`PreviousMonth()`: Gets the DatetimeSpan for the previous month.

`CurrentYear()`: Gets the DatetimeSpan for the current year.

`NextYear()`: Gets the DatetimeSpan for the next year.

`PreviousYear()`: Gets the DatetimeSpan for the previous year.

`MonthOfYear()`: Gets the DatetimeSpan for a specific month of a specific year.

`Year()`: Gets the DatetimeSpan for a specific year.

`Overlaps()`: Determines if two DatetimeSpans overlap.

`GetIntersection()`: Gets the intersection of two DatetimeSpans.

`MergeSpans()`: Merges multiple DatetimeSpans into a single continuous span.

`SplitSpan()`: Splits a DatetimeSpan into equal-sized intervals.

`GenerateDailySpans()`: Generates recurring daily DatetimeSpans.

`GenerateWeeklySpans()`: Generates recurring weekly DatetimeSpans.

`GenerateMonthlySpans()`: Generates recurring monthly DatetimeSpans.

`GetDuration()`: Calculates the total duration of a DatetimeSpan.

`ExtendSpan()`: Extends a DatetimeSpan by a specified duration.

##### DatetimeHelper

`AddWeeks()`: Adds a specified number of weeks to a DateTime.

`GetStartOfDay()`: Gets the start of the day for a given DateTime.

`GetEndOfDay()`: Gets the end of the day for a given DateTime.

`GetStartOfWeek()`: Gets the start of the week for a given DateTime.

`GetEndOfWeek()`: Gets the end of the week for a given DateTime.

`GetStartOfMonth()`: Gets the start of the month for a given DateTime.

`GetEndOfMonth()`: Gets the end of the month for a given DateTime.

`GetStartOfYear()`: Gets the start of the year for a given DateTime.

`GetEndOfYear()`: Gets the end of the year for a given DateTime.

`GetNextBusinessDay()`: Gets the next business day from the given DateTime.

`GetPreviousBusinessDay()`: Gets the previous business day from the given DateTime.

`GetBusinessDaysBetween()`: Calculates the number of business days between two dates.

`IsHoliday()`: Checks if a given date is a holiday.

`GetNearestWorkday()`: Gets the nearest workday to the given date.

`GetAge()`: Calculates the age based on the given birthdate.

`GetExactAge()`: Calculates the exact age with precision to days.

`GetWorkdaysInPeriod()`: Calculates the number of workdays in a given period.

`IsWeekend()`: Determines if a given date is a weekend.

### Utilbox.Enums

#### EnumHelper

`IsValidEnumValue()`: Checks if the given integer value is a valid value for the specified enum type.

`GetEnumValuesWithDescriptions()`: Returns a list of KeyValuePair where the key is the integer value of the enum and the value is the description attribute.

`GetEnumByDisplayName()`: Gets the enum value based on the display name attribute.

`GetEnumByDescription()`: Gets the enum value based on the description attribute.

`GetDescriptionByDisplayName()`: Gets the description attribute based on the display name of the enum value.

`GetAllValues()`: Gets all values of an enum type.

`ParseEnum()`: Parses an enum value from a string, with case-insensitive matching.

`GetEnumDisplayNames()`: Gets a collection of enum values with their corresponding display names.

`GetEnumDescriptions()`: Gets a collection of enum values with their corresponding descriptions.

`CombineFlags()`: Combines multiple enum flags.

`RemoveFlag()`: Removes a specific flag from an enum value.

#### EnumExtensions

`GetDisplayName()`: Gets the display name of the enum value.

`GetDescription()`: Gets the description of the enum value.

`ToInt()`: Converts an enum value to its corresponding integer value.

`HasFlag()`: Determines if the current enum value has a specific flag set.

### Utilbox.Result

#### Result

`IsSuccess`: Gets a boolean indicating whether the operation was successful.

`IsFailure`: Gets a boolean indicating whether the operation was a failure.

`Errors`: A list of error messages. Empty if the operation was successful.

`Success()`: Creates a successful result with no errors.

`Failure()`: Creates a failed result with a single error message.

`Failure(IEnumerable<string> errors)`: Creates a failed result with multiple error messages.

`Combine()`: Combines multiple results into a single result. If any of the results are failures, the combined result will also be a failure.

`OnSuccess()`: Executes an action if the result is successful.

`OnFailure()`: Executes an action if the result is a failure.

`Try()`: Attempts to execute an action, returning a result based on success or failure.

#### Result< T >

`Value`: Gets the value associated with the result if it is successful.

`Success()`: Creates a successful result with the given value.

`Failure()`: Creates a failed result with a single error message.

`Failure(IEnumerable<string>? errors)`: Creates a failed result with multiple error messages.

`Map<TOut>(Func<T, TOut> mapFunc)`: Maps the current result into a new result of type TOut based on the success status.

`OnSuccess()`: Executes an action if the result is successful.

`OnFailure()`: Executes an action if the result is a failure.

### Utilbox.Strings

#### StringConversionHelper

- ToTitleCase(string input): Converts a string to title case (each word capitalized).
- ToCamelCase(string input): Converts a string to camel case.
- ToSnakeCase(string input): Converts a string to snake_case.
- ToKebabCase(string input): Converts a string to kebab-case.

#### StringManipulationHelper

- TrimToLength(string input, int maxLength): Trims a string to a specific length and appends an ellipsis if trimmed.
- SafeSubstring(string input, int start, int length): Safely extracts a substring from the input string.
- RemoveWhiteSpaces(string input): Removes all whitespace characters from the string.
- ReplaceMultiple(string input, Dictionary<string, string> replacements): Replaces all occurrences of multiple strings with their replacements.
- Reverse(string input): Reverses the characters in the input string.
  StringCheckerHelper

- IsValidEmail(string email): Checks if the input string is a valid email address.
- IsAlphabetic(string input): Checks if a string contains only alphabetic characters.
- ContainsOnlyDigits(string input): Checks if a string contains only numeric digits.
- IsPalindrome(string input): Checks if the input string is a palindrome (case-insensitive).
- IsValidUrl(string input): Checks if a string contains a valid URL format.
- StartsWithAny(string input, params string[] prefixes): Checks if a string starts with any of the given prefixes.
- EndsWithAny(string input, params string[] suffixes): Checks if a string ends with any of the given suffixes.

### Utilbox.Pagination

#### PaginatedResult<T>

- Items: The items on the current page.
- PageNumber: The current page number (1-based index).
- PageSize: The size of the page (number of items per page).
- TotalItems: The total number of items across all pages.
- TotalPages: The total number of pages.
- HasNextPage: Indicates whether there is a next page.
- HasPreviousPage: Indicates whether there is a previous page.

#### PaginationHelper

- Paginate<T>(IEnumerable<T> items, uint pageNumber, uint pageSize): Creates a paginated result from a collection of items.
- PaginateAsync<T>(IQueryable<T> query, uint pageNumber, uint pageSize): Creates a paginated result from an IQueryable source, optimized for database queries.

---

### 🌟 Dependencies

.NET Standard 2.0

You can check supported frameworks here:
https://docs.microsoft.com/pt-br/dotnet/standard/net-standard

---

### ⚡ License

Utilbox is licensed under the MIT License.

---

### 👨‍💻 About the Author

Utilbox was created by Rafael Ferreira under RAZ Solutions. If you have any questions or would like more information, feel free to contact me!
