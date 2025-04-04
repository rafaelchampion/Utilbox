# Utilbox.Strings

A comprehensive string utility library for .NET applications that provides a wide range of string manipulation, validation, and casing transformation functions.

## Features

### String Manipulation

- Trim strings to specified length with ellipsis
- Safe substring extraction
- Remove whitespace
- Remove accents/diacritics
- Remove non-alphanumeric characters
- Multiple string replacements
- String reversal (full string and words)

### String Validation

- Email validation
- Alphabetic character checking
- Numeric value validation
- Digit-only validation
- Palindrome checking
- URL validation
- Prefix/suffix checking
- ISBN validation (ISBN-10 and ISBN-13)

### String Casing

- Title case conversion
- Camel case conversion
- Snake case conversion
- Kebab case conversion
- Pascal case conversion

## Installation

### Package Manager Console

```powershell
Install-Package Utilbox.Strings
```

### .NET CLI

```bash
dotnet add package Utilbox.Strings
```

## Usage Examples

### String Manipulation

```csharp
// Trim with ellipsis
string longText = "This is a very long text that needs to be trimmed";
string trimmed = longText.TrimToLength(20); // Returns "This is a very long..."

// Safe substring
string text = "Hello World";
string safe = text.SafeSubstring(6, 5); // Returns "World"

// Remove whitespace
string spaced = "Hello   World";
string compact = spaced.RemoveWhiteSpaces(); // Returns "HelloWorld"

// Remove accents
string accented = "café";
string plain = accented.RemoveAccents(); // Returns "cafe"

// Remove non-alphanumeric
string mixed = "Hello! @World#123";
string clean = mixed.RemoveNonAlphanumeric(); // Returns "HelloWorld123"

// Multiple replacements
var replacements = new Dictionary<string, string>
{
    { "Hello", "Hi" },
    { "World", "Earth" }
};
string text = "Hello World";
string replaced = text.ReplaceMultiple(replacements); // Returns "Hi Earth"

// Reverse string
string text = "Hello";
string reversed = text.Reverse(); // Returns "olleH"

// Reverse words
string text = "Hello World";
string reversed = text.ReverseWords(); // Returns "World Hello"
```

### String Validation

```csharp
// Email validation
bool isValidEmail = "user@example.com".IsValidEmail();

// Alphabetic check
bool isAlpha = "Hello".IsAlphabetic(); // true
bool isNotAlpha = "Hello123".IsAlphabetic(); // false

// Numeric validation
bool isNumeric = "123.45".IsNumeric(); // true
bool isNotNumeric = "123.45a".IsNumeric(); // false

// Digit-only check
bool isDigitsOnly = "12345".ContainsOnlyDigits(); // true
bool isNotDigitsOnly = "12345a".ContainsOnlyDigits(); // false

// Palindrome check
bool isPalindrome = "radar".IsPalindrome(); // true
bool isNotPalindrome = "hello".IsPalindrome(); // false

// URL validation
bool isValidUrl = "https://example.com".IsValidUrl();

// Prefix/suffix checking
bool startsWith = "Hello World".StartsWithAny("Hi", "Hello"); // true
bool endsWith = "Hello World".EndsWithAny("World", "Earth"); // true

// ISBN validation
bool isValidIsbn10 = "0-7475-3269-9".IsValidIsbn(); // true
bool isValidIsbn13 = "978-0-7475-3269-9".IsValidIsbn(); // true
```

### String Casing

```csharp
// Title case
string title = "hello world".ToTitleCase(); // Returns "Hello World"

// Camel case
string camel = "Hello World".ToCamelCase(); // Returns "helloWorld"

// Snake case
string snake = "HelloWorld".ToSnakeCase(); // Returns "hello_world"

// Kebab case
string kebab = "HelloWorld".ToKebabCase(); // Returns "hello-world"

// Pascal case
string pascal = "hello world".ToPascalCase(); // Returns "HelloWorld"
```

## Requirements

- .NET Standard 2.0 or higher

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
