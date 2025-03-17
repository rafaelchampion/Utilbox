using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Utilbox.Strings;
public static class StringManipulationExtensions
{
    /// <summary>
    /// Trims the input string to the specified maximum length and appends ellipsis if trimmed.
    /// </summary>
    /// <param name="input">The input string to trim.</param>
    /// <param name="maxLength">The maximum length of the trimmed string.</param>
    /// <returns>The trimmed string with ellipsis appended if it was trimmed, otherwise the original string.</returns>
    public static string TrimToLength(this string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input) || maxLength <= 0) return string.Empty;
        return input.Length > maxLength ? input.Substring(0, maxLength) + "..." : input;
    }

    /// <summary>
    /// Safely extracts a substring from the input string starting at the specified position and with the specified length.
    /// </summary>
    /// <param name="input">The input string to extract the substring from.</param>
    /// <param name="start">The starting position of the substring.</param>
    /// <param name="length">The length of the substring.</param>
    /// <returns>The extracted substring, or an empty string if the input is null or the start position is invalid.</returns>
    public static string SafeSubstring(this string input, int start, int length)
    {
        if (string.IsNullOrEmpty(input) || start < 0 || start >= input.Length) return string.Empty;
        return input.Substring(start, Math.Min(length, input.Length - start));
    }

    /// <summary>
    /// Removes all white spaces from the input string.
    /// </summary>
    /// <param name="input">The input string to remove white spaces from.</param>
    /// <returns>The input string without any white spaces.</returns>
    public static string RemoveWhiteSpaces(this string input)
    {
        return string.IsNullOrEmpty(input)
            ? input
            : new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }

    /// <summary>
    /// Removes diacritical marks (accents) from the string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string without accents.</returns>
    public static string RemoveAccents(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        string normalizedString = text.Normalize(NormalizationForm.FormD);
        var result = new StringBuilder();
        foreach (char c in normalizedString)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                result.Append(c);
            }
        }
        return result.ToString().Normalize(NormalizationForm.FormC);
    }

    /// <summary>
    /// Removes all non-alphanumeric characters from the string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string containing only letters and digits.</returns>
    public static string RemoveNonAlphanumeric(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        return new string(input.Where(char.IsLetterOrDigit).ToArray());
    }

    /// <summary>
    /// Replaces multiple substrings in the input string based on the specified replacements' dictionary.
    /// </summary>
    /// <param name="input">The input string to perform replacements on.</param>
    /// <param name="replacements">A dictionary containing the substrings to replace as keys and their replacements as values.</param>
    /// <returns>The input string with the specified replacements applied.</returns>
    public static string ReplaceMultiple(this string input, IDictionary<string, string>? replacements)
    {
        if (string.IsNullOrEmpty(input) || replacements == null) return input;
        return replacements.Aggregate(input,
            (current, replacement) => current.Replace(replacement.Key, replacement.Value));
    }

    /// <summary>
    /// Reverses the characters in the input string.
    /// </summary>
    /// <param name="input">The input string to reverse.</param>
    /// <returns>The input string with its characters in reverse order.</returns>
    public static string Reverse(this string input)
    {
        if (input == null) return null;
        var charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Reverses the order of words in the input string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string with word order reversed.</returns>
    public static string ReverseWords(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        var words = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(" ", words);
    }
}
