using System.Text.RegularExpressions;

namespace Utilbox.Strings;

public static class StringConversionHelper
{
    /// <summary>
    /// Converts a string to title case (each word capitalized).
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The title-cased string.</returns>
    public static string ToTitleCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
        return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
    }

    /// <summary>
    /// Converts a string to camel case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The camel-cased string.</returns>
    public static string ToCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToLower(input[0]) + input.Substring(1);
    }

    /// <summary>
    /// Converts a string to snake_case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The snake_cased string.</returns>
    public static string ToSnakeCase(string input)
    {
        return string.IsNullOrWhiteSpace(input)
            ? input
            : Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }

    /// <summary>
    /// Converts a string to kebab-case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The kebab-cased string.</returns>
    public static string ToKebabCase(string input)
    {
        return string.IsNullOrWhiteSpace(input)
            ? input
            : Regex.Replace(input, "([a-z0-9])([A-Z])", "$1-$2").ToLower();
    }
}