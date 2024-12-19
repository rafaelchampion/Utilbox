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
        return input.All(char.IsDigit);
    }
        
    /// <summary>
    /// Checks if the input string is a palindrome (case-insensitive).
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        var reversed = new string(input.ToLower().Reverse().ToArray());
        return input.ToLower() == reversed;
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
}