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

<details>
  <summary>Utilbox.Dates</summary>

  ## Utilbox.Dates

Provides various utility methods for working with dates.

##### DatetimeSpan Struct

The `DatetimeSpan` struct represents a span of time between two `DateTime` values. It ensures that the start date is always before the end date.

**Properties:**
- `DateTime Start`: The start date of the span.
- `DateTime End`: The end date of the span.

**Constructor:**
- `DatetimeSpan(DateTime start, DateTime end)`: Initializes a new instance of the `DatetimeSpan` struct. Throws an `ArgumentException` if the start date is after the end date.

<table>
<thead>
<tr><td colspan='2'><center><b>DatetimeHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>AddWeeks</td>
<td>Adds a specified number of weeks to a DateTime.</td>
</tr>
<tr>
<td>GetAge</td>
<td>Calculates the age based on the given birthdate.</td>
</tr>
<tr>
<td>GetBusinessDaysBetween</td>
<td>Calculates the number of business days between two dates.</td>
</tr>
<tr>
<td>GetEndOfDay</td>
<td>Gets the end of the day for a given DateTime.</td>
</tr>
<tr>
<td>GetEndOfMonth</td>
<td>Gets the end of the month for a given DateTime.</td>
</tr>
<tr>
<td>GetEndOfWeek</td>
<td>Gets the end of the week for a given DateTime.</td>
</tr>
<tr>
<td>GetEndOfYear</td>
<td>Gets the end of the year for a given DateTime.</td>
</tr>
<tr>
<td>GetExactAge</td>
<td>Calculates the exact age with precision to days.</td>
</tr>
<tr>
<td>GetNearestWorkday</td>
<td>Gets the nearest workday to the given date.</td>
</tr>
<tr>
<td>GetNextBusinessDay</td>
<td>Gets the next business day from the given DateTime.</td>
</tr>
<tr>
<td>GetPreviousBusinessDay</td>
<td>Gets the previous business day from the given DateTime.</td>
</tr>
<tr>
<td>GetStartOfDay</td>
<td>Gets the start of the day for a given DateTime.</td>
</tr>
<tr>
<td>GetStartOfMonth</td>
<td>Gets the start of the month for a given DateTime.</td>
</tr>
<tr>
<td>GetStartOfWeek</td>
<td>Gets the start of the week for a given DateTime.</td>
</tr>
<tr>
<td>GetStartOfYear</td>
<td>Gets the start of the year for a given DateTime.</td>
</tr>
<tr>
<td>GetWorkdaysInPeriod</td>
<td>Calculates the number of workdays in a given period.</td>
</tr>
<tr>
<td>IsHoliday</td>
<td>Checks if a given date is a holiday.</td>
</tr>
<tr>
<td>IsWeekend</td>
<td>Determines if a given date is a weekend.</td>
</tr>
</tbody>
<thead>
<tr><td colspan='2'><center><b>DatetimeSpanHelper</b></center></td></tr>
</thead>
<tbody>
<td>CurrentDay</td>
<td>Gets the DatetimeSpan for the current day.</td>
</tr>
<tr>
<td>CurrentMonth</td>
<td>Gets the DatetimeSpan for the current month.</td>
</tr>
<tr>
<td>CurrentWeek</td>
<td>Gets the DatetimeSpan for the current week.</td>
</tr>
<tr>
<td>CurrentYear</td>
<td>Gets the DatetimeSpan for the current year.</td>
</tr>
<tr>
<td>ExtendSpan</td>
<td>Extends a DatetimeSpan by a specified duration.</td>
</tr>
<tr>
<td>GenerateDailySpans</td>
<td>Generates recurring daily DatetimeSpans.</td>
</tr>
<tr>
<td>GenerateMonthlySpans</td>
<td>Generates recurring monthly DatetimeSpans.</td>
</tr>
<tr>
<td>GenerateWeeklySpans</td>
<td>Generates recurring weekly DatetimeSpans.</td>
</tr>
<tr>
<td>GetDuration</td>
<td>Calculates the total duration of a DatetimeSpan.</td>
</tr>
<tr>
<td>GetIntersection</td>
<td>Gets the intersection of two DatetimeSpans.</td>
</tr>
<tr>
<td>MergeSpans</td>
<td>Merges multiple DatetimeSpans into a single continuous span.</td>
</tr>
<tr>
<td>MonthOfYear</td>
<td>Gets the DatetimeSpan for a specific month of a specific year.</td>
</tr>
<tr>
<td>NextDay</td>
<td>Gets the DatetimeSpan for the next day.</td>
</tr>
<tr>
<td>NextMonth</td>
<td>Gets the DatetimeSpan for the next month.</td>
</tr>
<tr>
<td>NextYear</td>
<td>Gets the DatetimeSpan for the next year.</td>
</tr>
<tr>
<td>Overlaps</td>
<td>Determines if two DatetimeSpans overlap.</td>
</tr>
<tr>
<td>PreviousDay</td>
<td>Gets the DatetimeSpan for the previous day.</td>
</tr>
<tr>
<td>PreviousMonth</td>
<td>Gets the DatetimeSpan for the previous month.</td>
</tr>
<tr>
<td>PreviousYear</td>
<td>Gets the DatetimeSpan for the previous year.</td>
</tr>
<tr>
<td>SplitSpan</td>
<td>Splits a DatetimeSpan into equal-sized intervals.</td>
</tr>
<tr>
<td>Year</td>
<td>Gets the DatetimeSpan for a specific year.</td>
</tr>
</tbody>
</table>

</details>

<details>
<summary>Utilbox.Enums</summary>

## Utilbox.Enums

Provides various utility methods for working with enums.

<table>
<thead>
<tr><td colspan='2'><center><b>EnumHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>IsValidEnumValue</td>
<td>Checks if the given integer value is a valid value for the specified enum type.</td>
</tr>
<tr>
<td>GetEnumValuesWithDescriptions</td>
<td>Returns a list of KeyValuePair where the key is the integer value of the enum and the value is the description attribute.</td>
</tr>
<tr>
<td>GetEnumByDisplayName</td>
<td>Gets the enum value based on the display name attribute.</td>
</tr>
<tr>
<td>GetEnumByDescription</td>
<td>Gets the enum value based on the description attribute.</td>
</tr>
<tr>
<td>GetDescriptionByDisplayName</td>
<td>Gets the description attribute based on the display name of the enum value.</td>
</tr>
<tr>
<td>GetAllValues</td>
<td>Gets all values of an enum type.</td>
</tr>
<tr>
<td>ParseEnum</td>
<td>Parses an enum value from a string, with case-insensitive matching.</td>
</tr>
<tr>
<td>GetEnumDisplayNames</td>
<td>Gets a collection of enum values with their corresponding display names.</td>
</tr>
<tr>
<td>GetEnumDescriptions</td>
<td>Gets a collection of enum values with their corresponding descriptions.</td>
</tr>
<tr>
<td>CombineFlags</td>
<td>Combines multiple enum flags.</td>
</tr>
<tr>
<td>RemoveFlag</td>
<td>Removes a specific flag from an enum value.</td>
</tr>
</tbody>
<thead>
<tr><td colspan='2'><center><b>EnumExtensions</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>GetDisplayName</td>
<td>Gets the display name of the enum value.</td>
</tr>
<tr>
<td>GetDescription</td>
<td>Gets the description of the enum value.</td>
</tr>
<tr>
<td>ToInt</td>
<td>Converts an enum value to its corresponding integer value.</td>
</tr>
<tr>
<td>HasFlag</td>
<td>Determines if the current enum value has a specific flag set.</td>
</tr>
</tbody>
</table>

</details>

<details>
<summary>Utilbox.Pagination</summary>

## Utilbox.Pagination

Provides various utility methods for working with pagination.

##### PaginatedResult Class

The `PaginatedResult` class represents a paginated result with metadata.

**Properties:**
- `IReadOnlyCollection<T> Items`: The items on the current page.
- `uint PageNumber`: The current page number (1-based index).
- `uint PageSize`: The size of the page (number of items per page).
- `uint TotalItems`: The total number of items across all pages.
- `uint TotalPages`: The total number of pages.
- `bool HasNextPage`: Indicates whether there is a next page.
- `bool HasPreviousPage`: Indicates whether there is a previous page.

**Constructor:**
- `PaginatedResult(IEnumerable<T> items, uint pageNumber, uint pageSize, uint totalItems, uint totalPages)`: Initializes a new instance of the `PaginatedResult` class.

<table>
<thead>
<tr><td colspan='2'><center><b>PaginationHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>Paginate</td>
<td>Creates a paginated result from a collection of items.</td>
</tr>
<tr>
<td>PaginateAsync</td>
<td>Creates a paginated result from an IQueryable source, optimized for database queries.</td>
</tr>
</tbody>
</table>

</details>

<details>
<summary>Utilbox.Result</summary>

## Utilbox.Result

Provides various utility methods for working with the Result pattern.

##### Result Class

The `Result` class represents the outcome of an operation. It can be either successful or failed, containing errors if failed.

**Properties:**
- `bool IsSuccess`: Gets a boolean indicating whether the operation was successful.
- `bool IsFailure`: Gets a boolean indicating whether the operation was a failure.
- `IList<string>? Errors`: A list of error messages. Empty if the operation was successful.

**Constructor:**
- `Result(bool isSuccess, params string[] errors)`: Initializes a new instance of the `Result` class with the specified success status and optional errors.
- `Result()`: Initializes a new instance of the `Result` class with no errors.

**Methods:**
- `static Result Success()`: Creates a successful result with no errors.
- `static Result Failure(string error)`: Creates a failed result with a single error message.
- `static Result Failure(IEnumerable<string> errors)`: Creates a failed result with multiple error messages.
- `static Result Combine(params Result[] results)`: Combines multiple results into a single result. If any of the results are failures, the combined result will also be a failure.
- `Result OnSuccess(Action action)`: Executes an action if the result is successful.
- `Result OnFailure(Action action)`: Executes an action if the result is a failure.
- `static Result Try(Action action)`: Attempts to execute an action, returning a result based on success or failure.

##### Result< T > Class

The `Result<T>` class represents a result with a value of type `T`. It can be either successful or failed.

**Properties:**
- `T Value`: Gets the value associated with the result if it is successful.

**Constructor:**
- `Result(bool isSuccess, T value, params string[]? errors)`: Initializes a new instance of the `Result<T>` class with the specified success status, value, and optional errors.

**Methods:**
- `static Result<T> Success(T data)`: Creates a successful result with the given value.
- `static Result<T> Failure(string error)`: Creates a failed result with a single error message.
- `static Result<T> Failure(IEnumerable<string>? errors)`: Creates a failed result with multiple error messages.
- `Result<TOut> Map<TOut>(Func<T, TOut> mapFunc)`: Maps the current result into a new result of type `TOut` based on the success status.
- `new Result<T> OnSuccess(Action action)`: Executes an action if the result is successful.
- `new Result<T> OnFailure(Action action)`: Executes an action if the result is a failure.

<table>
<thead>
<tr><td colspan='2'><center><b>ResultExtensions</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>Chain</td>
<td>Chains multiple Result-returning operations together synchronously.</td>
</tr>
<tr>
<td>ChainAsync</td>
<td>Chains multiple Result-returning operations together asynchronously.</td>
</tr>
<tr>
<td>OnSuccess</td>
<td>Executes a synchronous transformation on the value of a successful Result.</td>
</tr>
<tr>
<td>OnSuccessAsync</td>
<td>Executes an asynchronous transformation on the value of a successful Result.</td>
</tr>
</tbody>
</table>

</details>

<details>
<summary>Utilbox.Strings</summary>

## Utilbox.Strings

Provides various utility methods for working with strings.

<table>
<thead>
<tr><td colspan='2'><center><b>StringCheckerHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>IsValidEmail</td>
<td>Checks if the input string is a valid email address.</td>
</tr>
<tr>
<td>IsAlphabetic</td>
<td>Checks if a string contains only alphabetic characters.</td>
</tr>
<tr>
<td>ContainsOnlyDigits</td>
<td>Checks if a string contains only numeric digits.</td>
</tr>
<tr>
<td>IsPalindrome</td>
<td>Checks if the input string is a palindrome (case-insensitive).</td>
</tr>
<tr>
<td>IsValidUrl</td>
<td>Checks if a string contains a valid URL format.</td>
</tr>
<tr>
<td>StartsWithAny</td>
<td>Checks if a string starts with any of the given prefixes.</td>
</tr>
<tr>
<td>EndsWithAny</td>
<td>Checks if a string ends with any of the given suffixes.</td>
</tr>
<tr>
<td>IsValidIsbn</td>
<td>Validates if the given ISBN is in a valid format (either ISBN-10 or ISBN-13).</td>
</tr>
</tbody>
<thead>
<tr><td colspan='2'><center><b>StringConversionHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>ToTitleCase</td>
<td>Converts a string to title case (each word capitalized).</td>
</tr>
<tr>
<td>ToCamelCase</td>
<td>Converts a string to camel case.</td>
</tr>
<tr>
<td>ToSnakeCase</td>
<td>Converts a string to snake_case.</td>
</tr>
<tr>
<td>ToKebabCase</td>
<td>Converts a string to kebab-case.</td>
</tr>
</tbody>
<thead>
<tr><td colspan='2'><center><b>StringManipulationHelper</b></center></td></tr>
</thead>
<tbody>
<tr>
<td>TrimToLength</td>
<td>Trims a string to a specific length and appends an ellipsis if trimmed.</td>
</tr>
<tr>
<td>SafeSubstring</td>
<td>Safely extracts a substring from the input string.</td>
</tr>
<tr>
<td>RemoveWhiteSpaces</td>
<td>Removes all whitespace characters from the string.</td>
</tr>
<tr>
<td>ReplaceMultiple</td>
<td>Replaces all occurrences of multiple strings with their replacements.</td>
</tr>
<tr>
<td>Reverse</td>
<td>Reverses the characters in the input string.</td>
</tr>
</tbody>
</table>

</details>

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
