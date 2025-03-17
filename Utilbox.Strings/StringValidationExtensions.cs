using System;
using System.Globalization;
using System.Linq;
using System.Net.Mail;

namespace Utilbox.Strings;

public static class StringValidationExtensions
{
    /// <summary>
    /// Checks if the provided string is a valid email address.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>True if the email address is valid, otherwise false.</returns>
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if the provided string contains only alphabetic characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string contains only alphabetic characters, otherwise false.</returns>
    public static bool IsAlphabetic(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
    }

    /// <summary>
    /// Checks if the string represents a numeric value.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>True if the string is numeric; otherwise, false.</returns>
    public static bool IsNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;
        return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }

    /// <summary>
    /// Checks if the provided string contains only digit characters.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string contains only digit characters, otherwise false.</returns>
    public static bool ContainsOnlyDigits(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
    }

    /// <summary>
    /// Checks if the provided string is a palindrome.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string is a palindrome, otherwise false.</returns>
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        int left = 0, right = input.Length - 1;
        while (left < right)
        {
            if (char.ToLowerInvariant(input[left]) != char.ToLowerInvariant(input[right]))
                return false;
            left++;
            right--;
        }

        return true;
    }

    /// <summary>
    /// Checks if the provided string is a valid URL.
    /// </summary>
    /// <param name="input">The URL to validate.</param>
    /// <returns>True if the URL is valid, otherwise false.</returns>
    public static bool IsValidUrl(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        return Uri.TryCreate(input, UriKind.Absolute, out _) &&
               (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                input.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Checks if the provided string starts with any of the specified prefixes.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <param name="prefixes">The prefixes to check against.</param>
    /// <returns>True if the string starts with any of the specified prefixes, otherwise false.</returns>
    public static bool StartsWithAny(this string? input, params string[]? prefixes)
    {
        if (input == null) return false;
        return prefixes != null && prefixes.Any(prefix => input.StartsWith(prefix, StringComparison.Ordinal));
    }

    /// <summary>
    /// Checks if the provided string ends with any of the specified suffixes.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <param name="suffixes">The suffixes to check against.</param>
    /// <returns>True if the string ends with any of the specified suffixes, otherwise false.</returns>
    public static bool EndsWithAny(this string? input, params string[]? suffixes)
    {
        if (input == null) return false;
        return suffixes != null && suffixes.Any(suffix => input.EndsWith(suffix, StringComparison.Ordinal));
    }

    #region ISBN Validation

    /// <summary>
    /// Checks if the provided string is a valid ISBN (either ISBN-10 or ISBN-13).
    /// </summary>
    /// <param name="isbn">The ISBN to validate.</param>
    /// <returns>True if the ISBN is valid, otherwise false.</returns>
    public static bool IsValidIsbn(this string? isbn)
    {
        if (string.IsNullOrEmpty(isbn)) return false;
        isbn = isbn.Replace("-", "").Replace(" ", "");
        return isbn.Length switch
        {
            10 => IsValidIsbn10(isbn),
            13 => IsValidIsbn13(isbn),
            _ => false,
        };
    }

    /// <summary>
    /// Checks if the provided string is a valid ISBN-10.
    /// </summary>
    /// <param name="isbn">The ISBN-10 to validate.</param>
    /// <returns>True if the ISBN-10 is valid, otherwise false.</returns>
    private static bool IsValidIsbn10(string isbn)
    {
        if (isbn.Length != 10 || !isbn.Substring(0, 9).All(char.IsDigit))
            return false;

        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += (10 - i) * (isbn[i] - '0');
        }

        var check = isbn[9];
        sum += check == 'X' ? 10 : (check - '0');

        return sum % 11 == 0;
    }

    /// <summary>
    /// Checks if the provided string is a valid ISBN-13.
    /// </summary>
    /// <param name="isbn">The ISBN-13 to validate.</param>
    /// <returns>True if the ISBN-13 is valid, otherwise false.</returns>
    private static bool IsValidIsbn13(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            return false;

        var sum = 0;
        for (var i = 0; i < 12; i++)
        {
            var digit = isbn[i] - '0';
            sum += (i % 2 == 0) ? digit : digit * 3;
        }

        var checkDigit = (10 - (sum % 10)) % 10;

        return isbn[12] - '0' == checkDigit;
    }

    #endregion
}