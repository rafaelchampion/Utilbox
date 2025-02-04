using System;
using System.Linq;

namespace Utilbox.Strings;

public static class StringCheckerHelper
{
    /// <summary>
    /// Checks if the input string is a valid email address.
    /// </summary>
    /// <param name="email">The email string to validate.</param>
    /// <returns>True if the string is a valid email address; otherwise, false.</returns>
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if a string contains only alphabetic characters.
    /// </summary>
    /// /// <param name="input">The input string.</param>
    /// <returns>True if the string contains only alphabetic characters; otherwise, false.</returns>
    public static bool IsAlphabetic(string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
    }

    /// <summary>
    /// Checks if a string contains only numeric digits.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>True if the string contains only digits; otherwise, false.</returns>
    public static bool ContainsOnlyDigits(string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
    }

    /// <summary>
    /// Checks if the input string is a palindrome (case-insensitive).
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
    
        int left = 0, right = input.Length - 1;
        while (left < right)
        {
            var lChar = char.ToLowerInvariant(input[left]);
            var rChar = char.ToLowerInvariant(input[right]);
        
            if (lChar != rChar) return false;
        
            left++;
            right--;
        }
    
        return true;
    }

    /// <summary>
    /// Checks if a string contains a valid URL format.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string contains a valid URL format; otherwise, false.</returns>
    public static bool IsValidUrl(string input)
    {
        return Uri.TryCreate(input, UriKind.Absolute, out var _) &&
               (input.StartsWith("http://") || input.StartsWith("https://"));
    }

    /// <summary>
    /// Checks if a string starts with any of the given prefixes.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <param name="prefixes">The prefixes params to validate to.</param>
    /// <returns>True if the string starts with any of the params; otherwise, false.</returns>
    public static bool StartsWithAny(string input, params string[] prefixes)
    {
        return prefixes.Any(input.StartsWith);
    }

    /// <summary>
    /// Checks if a string ends with any of the given suffixes.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <param name="suffixes">The suffixes params to validate to.</param>
    /// <returns>True if the string ends with any of the params; otherwise, false.</returns>
    public static bool EndsWithAny(string input, params string[] suffixes)
    {
        return suffixes.Any(input.EndsWith);
    }

    #region === ISBN ===

    /// <summary>
    /// Validates if the given ISBN is in a valid format (either ISBN-10 or ISBN-13).
    /// </summary>
    /// <param name="isbn">The ISBN string to validate.</param>
    /// <returns>
    /// <c>true</c> if the ISBN is valid (either ISBN-10 or ISBN-13), otherwise <c>false</c>.
    /// </returns>
    public static bool IsValidIsbn(string isbn)
    {
        return isbn.Length switch
        {
            10 => IsValidIsbn10(isbn),
            13 => IsValidIsbn13(isbn),
            _ => false
        };
    }

    /// <summary>
    /// Validates if the given ISBN-10 is in a valid format.
    /// </summary>
    /// <param name="isbn">The ISBN-10 string to validate.</param>
    /// <returns>
    /// <c>true</c> if the ISBN-10 is valid, otherwise <c>false</c>.
    /// </returns>
    private static bool IsValidIsbn10(string isbn)
    {
        if (isbn.Length != 10 || !isbn.Substring(0, 9).All(char.IsDigit)) return false;
        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += (10 - i) * (isbn[i] - '0');
        }
        var checkDigit = isbn[9];
        sum += checkDigit == 'X' ? 10 : (checkDigit - '0');
        return sum % 11 == 0;
    }
    
    /// <summary>
    /// Validates if the given ISBN-13 is in a valid format.
    /// </summary>
    /// <param name="isbn">The ISBN-13 string to validate.</param>
    /// <returns>
    /// <c>true</c> if the ISBN-13 is valid, otherwise <c>false</c>.
    /// </returns>
    private static bool IsValidIsbn13(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit)) return false;
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