using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Strings;

public static class StringManipulationHelper
{
    /// <summary>
    /// Trims a string to a specific length and appends an ellipsis if trimmed.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <returns>The trimmed string with ellipsis if truncated.</returns>
    public static string TrimToLength(string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input) || maxLength <= 0) return string.Empty;
        return input.Length > maxLength ? input.Substring(0, maxLength) + "..." : input;
    }

    /// <summary>
    /// Safely extracts a substring from the input string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="start">The starting index.</param>
    /// <param name="length">The length of the substring.</param>
    /// <returns>The extracted substring or an empty string if out of range.</returns>
    public static string SafeSubstring(string input, int start, int length)
    {
        if (string.IsNullOrEmpty(input) || start < 0 || start >= input.Length) return string.Empty;
        return input.Substring(start, Math.Min(length, input.Length - start));
    }

    /// <summary>
    /// Removes all whitespace characters from the string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string with no whitespace.</returns>
    public static string RemoveWhiteSpaces(string input)
    {
        return string.IsNullOrEmpty(input) ? input : new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }

    /// <summary>
    /// Replaces all occurrences of multiple strings with their replacements.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="replacements">The dictionary of terms to replace.</param>
    /// <returns>A string with no whitespace.</returns>
    public static string ReplaceMultiple(string input, Dictionary<string, string> replacements)
    {
        if (string.IsNullOrEmpty(input) || replacements == null) return input;
        return replacements.Aggregate(input,
            (current, replacement) => current.Replace(replacement.Key, replacement.Value));
    }

    /// <summary>
    /// Reverses the characters in the input string.
    /// </summary>
    /// <param name="input">The string to reverse.</param>
    /// <returns>The reversed string.</returns>
    public static string? Reverse(string input)
    {
        if (input == null) return null;
        return new string(input.Reverse().ToArray());
    }
}