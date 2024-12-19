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

#### Utilbox.Dates

##### DatetimeSpan(DateTime start, DateTime end): Initializes a new instance of the DatetimeSpan struct.

##### DatetimeHelper

- AddWeeks(DateTime dateTime, int weeks): Adds a specified number of weeks to a DateTime.

- GetStartOfDay(DateTime dateTime): Gets the start of the day for a given DateTime.
- GetEndOfDay(DateTime dateTime): Gets the end of the day for a given DateTime.
- GetStartOfWeek(DateTime dateTime): Gets the start of the week for a given DateTime.
- GetEndOfWeek(DateTime dateTime): Gets the end of the week for a given DateTime.
- GetStartOfMonth(DateTime dateTime): Gets the start of the month for a given DateTime.
- GetEndOfMonth(DateTime dateTime): Gets the end of the month for a given DateTime.
- GetStartOfYear(DateTime dateTime): Gets the start of the year for a given DateTime.
- GetEndOfYear(DateTime dateTime): Gets the end of the year for a given DateTime.

- GetNextBusinessDay(DateTime dateTime): Gets the next business day from the given DateTime.
- GetPreviousBusinessDay(DateTime dateTime): Gets the previous business day from the given DateTime.
- GetBusinessDaysBetween(DateTime startDate, DateTime endDate): Calculates the number of business days between two dates.
- IsHoliday(DateTime dateTime, List<DateTime> holidayList): Checks if a given date is a holiday.
- GetNearestWorkday(DateTime dateTime): Gets the nearest workday to the given date.

- GetAge(DateTime birthDate): Calculates the age based on the given birthdate.
- GetExactAge(DateTime birthDate): Calculates the exact age with precision to days.
- GetWorkdaysInPeriod(DateTime startDate, DateTime endDate): Calculates the number of workdays in a given period.
- IsWeekend(DateTime dateTime): Determines if a given date is a weekend.
  DatetimeSpan

##### DatetimeSpanHelper

- CurrentDay(): Gets the DatetimeSpan for the current day.
- NextDay(): Gets the DatetimeSpan for the next day.
- PreviousDay(): Gets the DatetimeSpan for the previous day.
- CurrentWeek(): Gets the DatetimeSpan for the current week.
- CurrentMonth(): Gets the DatetimeSpan for the current month.
- NextMonth(): Gets the DatetimeSpan for the next month.
- PreviousMonth(): Gets the DatetimeSpan for the previous month.
- CurrentYear(): Gets the DatetimeSpan for the current year.
- NextYear(): Gets the DatetimeSpan for the next year.
- PreviousYear(): Gets the DatetimeSpan for the previous year.
- MonthOfYear(int year, int month): Gets the DatetimeSpan for a specific month of a specific year.
- Year(int year): Gets the DatetimeSpan for a specific year.

- Overlaps(DatetimeSpan span1, DatetimeSpan span2): Determines if two DatetimeSpans overlap.
- GetIntersection(DatetimeSpan span1, DatetimeSpan span2): Gets the intersection of two DatetimeSpans.
- MergeSpans(IEnumerable<DatetimeSpan> spans): Merges multiple DatetimeSpans into a single continuous span.
- SplitSpan(DatetimeSpan span, int intervalCount): Splits a DatetimeSpan into equal-sized intervals.
- GenerateDailySpans(DateTime startDate, int count, bool isUtc = true): Generates recurring daily DatetimeSpans.
- GenerateWeeklySpans(DateTime startDate, int count, bool isUtc = true): Generates recurring weekly DatetimeSpans.
- GenerateMonthlySpans(DateTime startDate, int count, bool isUtc = true): Generates recurring monthly DatetimeSpans.
- GetDuration(DatetimeSpan span): Calculates the total duration of a DatetimeSpan.
- ExtendSpan(DatetimeSpan span, TimeSpan extensionDuration, bool extendEnd = true): Extends a DatetimeSpan by a specified duration.

#### Utilbox.Enums

##### EnumHelper

- IsValidEnumValue<T>(int value) where T : struct, Enum: Checks if the given integer value is a valid value for the specified enum type.
- GetEnumValuesWithDescriptions<TEnum>() where TEnum : Enum: Returns a list of KeyValuePair where the key is the integer value of the enum and the value is the description attribute.
- GetEnumByDisplayName<TEnum>(string displayName) where TEnum : Enum: Gets the enum value based on the display name attribute.
- GetEnumByDescription<TEnum>(string description) where TEnum : Enum: Gets the enum value based on the description attribute.
- GetDescriptionByDisplayName<TEnum>(string displayName) where TEnum : Enum: Gets the description attribute based on the display name of the enum value.
- GetAllValues<TEnum>() where TEnum : Enum: Gets all values of an enum type.
- ParseEnum<TEnum>(string value, bool ignoreCase = true) where TEnum : Enum: Parses an enum value from a string, with case-insensitive matching.
- GetEnumDisplayNames<TEnum>() where TEnum : Enum: Gets a collection of enum values with their corresponding display names.
- GetEnumDescriptions<TEnum>() where TEnum : Enum: Gets a collection of enum values with their corresponding descriptions.
- CombineFlags<TEnum>(params TEnum[] flags) where TEnum : Enum: Combines multiple enum flags.
- RemoveFlag<TEnum>(this TEnum enumValue, TEnum flagToRemove) where TEnum : Enum: - Removes a specific flag from an enum value.

##### EnumExtensions

- GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : Enum: Gets the display name of the enum value.
- GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum: Gets the description of the enum value.
- ToInt<TEnum>(this TEnum enumValue) where TEnum : Enum: Converts an enum value to its corresponding integer value.
- HasFlag<TEnum>(this TEnum enumValue, TEnum flag) where TEnum : Enum: Determines if the current enum value has a specific flag set.

#### Utilbox.Result

##### Result

- IsSuccess: Gets a boolean indicating whether the operation was successful.
- IsFailure: Gets a boolean indicating whether the operation was a failure.
- Errors: A list of error messages. Empty if the operation was successful.
- Success(): Creates a successful result with no errors.
- Failure(string error): Creates a failed result with a single error message.
- Failure(IEnumerable<string> errors): Creates a failed result with multiple error messages.
- Combine(params Result[] results): Combines multiple results into a single result. If any of the results are failures, the combined result will also be a failure.
- OnSuccess(Action action): Executes an action if the result is successful.
- OnFailure(Action action): Executes an action if the result is a failure.
- Try(Action action): Attempts to execute an action, returning a result based on success or failure.

##### Result<T>

- Value: Gets the value associated with the result if it is successful.
- Success(T data): Creates a successful result with the given value.
- Failure(string error): Creates a failed result with a single error message.
- Failure(IEnumerable<string>? errors): Creates a failed result with multiple error messages.
- Map<TOut>(Func<T, TOut> mapFunc): Maps the current result into a new result of type TOut based on the success status.
- OnSuccess(Action action): Executes an action if the result is successful.
- OnFailure(Action action): Executes an action if the result is a failure.

#### Utilbox.Strings

##### StringConversionHelper

- ToTitleCase(string input): Converts a string to title case (each word capitalized).
- ToCamelCase(string input): Converts a string to camel case.
- ToSnakeCase(string input): Converts a string to snake_case.
- ToKebabCase(string input): Converts a string to kebab-case.

##### StringManipulationHelper

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

#### Utilbox.Pagination

##### PaginatedResult<T>

- Items: The items on the current page.
- PageNumber: The current page number (1-based index).
- PageSize: The size of the page (number of items per page).
- TotalItems: The total number of items across all pages.
- TotalPages: The total number of pages.
- HasNextPage: Indicates whether there is a next page.
- HasPreviousPage: Indicates whether there is a previous page.

##### PaginationHelper

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
