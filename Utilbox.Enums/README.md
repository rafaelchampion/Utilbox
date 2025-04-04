# Utilbox.Enums

A powerful enum utility library for .NET applications that provides enhanced enum functionality, attribute handling, and flag operations.

## Features

### Enum Extensions

- Get display names from `DisplayAttribute`
- Get descriptions from `DescriptionAttribute`
- Convert enum values to integers
- Custom flag checking with `HasFlagCustom`
- Thread-safe attribute caching

### Enum Utilities

- Validation and parsing:
  - Check if an integer value is valid for an enum
  - Parse enum values from strings with case sensitivity options
  - Try-parse enum values safely
- Attribute handling:
  - Get enum values with their descriptions
  - Get enum by display name or description
  - Get description by display name
  - Get all display names or descriptions as dictionaries
- Flag operations:
  - Combine multiple flags
  - Remove specific flags
  - Check for flag presence
- Collection operations:
  - Get all values of an enum type
  - Get enum values with descriptions as key-value pairs

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Enums
```

### .NET CLI

```bash
dotnet add package Utilbox.Enums
```

## Usage Examples

### Enum Extensions

```csharp
public enum Status
{
    [Display(Name = "In Progress")]
    [Description("Work is currently being done")]
    InProgress,

    [Display(Name = "Completed")]
    [Description("Work has been finished")]
    Completed
}

// Get display name
string displayName = Status.InProgress.GetDisplayName(); // Returns "In Progress"

// Get description
string description = Status.InProgress.GetDescription(); // Returns "Work is currently being done"

// Convert to integer
int value = Status.InProgress.ToInt();

// Check flags
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4
}

var permissions = Permissions.Read | Permissions.Write;
bool hasRead = permissions.HasFlagCustom(Permissions.Read); // Returns true
```

### Enum Utilities

```csharp
// Validation
bool isValid = EnumUtilities.IsValidEnumValue<Status>(1);

// Get values with descriptions
var valuesWithDescriptions = EnumUtilities.GetEnumValuesWithDescriptions<Status>();

// Parse from string
Status status = EnumUtilities.ParseEnum<Status>("InProgress");
bool success = EnumUtilities.TryParseEnum<Status>("InProgress", true, out var result);

// Get by display name or description
Status statusByName = EnumUtilities.GetEnumByDisplayName<Status>("In Progress");
Status statusByDesc = EnumUtilities.GetEnumByDescription<Status>("Work is currently being done");

// Get all display names or descriptions
var displayNames = EnumUtilities.GetEnumDisplayNames<Status>();
var descriptions = EnumUtilities.GetEnumDescriptions<Status>();

// Flag operations
var combined = EnumUtilities.CombineFlags(Permissions.Read, Permissions.Write);
var removed = combined.RemoveFlag(Permissions.Write);
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
