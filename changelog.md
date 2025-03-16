# Changelog

All notable changes to this project will be documented in this file.

## [2.0.0] - 2025-03-16

### Breaking Changes

This major release includes significant refactoring, renamed types/methods, and structural improvements. Backward compatibility is broken - update your code as follows:

## 🟥 Critical Breaking Changes

### 1. **Utilbox.Enums** (`1.1.0` → `2.0.0`)

- **`EnumHelper` class deleted**  
  All methods moved to **`EnumUtilities`**.

```csharp
// Old
EnumHelper.GetEnumDescriptions<MyEnum>();

// New
EnumUtilities.GetEnumDescriptions<MyEnum>();
```

- **Methods such as `GetDisplayName` and `GetDescription` now use caching (via `ConcurrentDictionary`) to improve performance.**

- **`HasFlag` renamed to `HasFlagCustom`**  
  Conflicts with `Enum.HasFlag` resolved.

```csharp
// Old
myEnumValue.HasFlag(flag);

// New
myEnumValue.HasFlagCustom(flag);
```

- **`FlagsAttribute` enforcement**
- `CombineFlags()`/`RemoveFlag()` now throw `InvalidOperationException` if enum lacks `[Flags]`.

### 2. **Utilbox.Strings** (`1.1.0` → `2.0.0`)

- Static helpers converted to extensions:

  - `StringCheckerHelper` → `StringValidationExtensions`

  - `StringConversionHelper` → `StringCasingExtensions`

  - `StringManipulationHelper` → `StringManipulationExtensions`

- **`StringCheckerHelper` class removed.**  
  All methods moved to **`StringValidationExtensions`**.

```csharp
// Old
StringCheckerHelper.IsValidEmail(str);

// New
str.IsValidEmail();
```

- **`StringConversionHelper` class removed.**  
  All methods moved to **`StringCasingExtensions`**.

```csharp
// Old
StringConversionHelper.ToTitleCase(str);

// New
str.ToTitleCase();
```

- **`StringManipulationHelper` class removed.**

  All methods moved to **`StringManipulationExtensions`**.

```csharp
// Old
StringManupulationHelper.TrimToLength(str, 10);

// New
str.TrimToLength(10);
```

### **3. Utilbox.Result (`1.1.0` → `2.0.0`)**

- **Property Mutability**:

  - **`IsSuccess` is now a read-only property.**

  - **`Result.Errors` has changed type from `IList<string>?` to `IReadOnlyList<string>`**

### **4. Utilbox.Pagination (`1.1.0` → `2.0.0`)**

- **`PaginationHelper` class removed.**  
  All methods moved to **`PaginationUtilities`**.

- `Paginate` method changed to extension **`ToPaginatedResult`**.

```csharp
// Old
PaginationHelper.Paginate(source, 1, 10);

// New
source.ToPaginatedResult(1, 10);
```

### **5. Utilbox.Dates (`1.1.0` → `2.0.0`)**

- **`DatetimeSpan` renamed to `DateRange`**  
  Update all references:

```csharp
// Old
DatetimeSpan range;

// New
DateRange range;
```

- **Split helpers into extensions**:

  - `DatetimeHelper` → `DateTimeUtilities`, `DateTimeExtensions`

  - `DatetimeSpanHelper` → `DateRangeUtilities`, `DateRangeExtensions`

- **`IsHoliday` and `IsWeekend` changed to extension methods.**

- **Method signature changes**:
  - `IsHoliday` now requires `IList<DateTime>` instead of `IEnumerable<DateTime>`.

## 🟩 New functionality

### **Utilbox.Result (`1.1.0` → `2.0.0`)**

- **Utility Methods**:

  - **Implicit Conversion**: `Result` now supports implicit conversion to bool for ease of use.

  - **`OnFailure(Action<IReadOnlyCollection<string>>)`**: Execute actions when a failure occurs.

  - **Try Overloads**: New overloads for executing actions with exception handling.

  - **`Match<TOut>`**: Pattern-match the result for success or failure processing.

  - **Ensure**: Validate the result’s value against a predicate, returning a failure if not met.

## 🟦 Other Notable Changes

- General Across All Projects

  - Improved XML.

  - Performance pass.

- Strings

  - **New methods:** `ReverseWords`, `RemoveAccents`, `TryParseEnum`.

  - **ISBN validation:** Now ignores hyphens/spaces automatically.

- Result

- **New methods: `Match`, `Ensure`, and granular error handling with `Try` overloads**.

- Dates

- **New date utilities: `EnumerateDays`, `EnumerateMonths`, and recurring span generators.**

## 🟧 Migration Checklist

- Replace all *.Helper classes with *Utilities/extensions.

- Rename HasFlag → HasFlagCustom in enums.

- Convert static method calls to extensions (e.g., str.IsValidEmail()).

- Update DatetimeSpan → DateRange.

- Audit [Flags] usage in enums.

- Replace IList<string> Errors with IReadOnlyList<string>.
