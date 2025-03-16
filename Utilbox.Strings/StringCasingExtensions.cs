using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utilbox.Strings;
/// <summary>
/// Provides extension methods for string casing transformations.
/// </summary>
public static class StringCasingExtensions
{
    /// <summary>
    /// Converts the specified string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The title-cased string.</returns>
    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var cultureInfo = CultureInfo.CurrentCulture;
        return cultureInfo.TextInfo.ToTitleCase(input.ToLower());
    }

    /// <summary>
    /// Converts the specified string to camel case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The camel-cased string.</returns>
    public static string ToCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToLowerInvariant(input[0]) + input.Substring(1);
    }

    /// <summary>
    /// Converts the specified string to snake case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The snake-cased string.</returns>
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        return Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }

    /// <summary>
    /// Converts the specified string to kebab case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The kebab-cased string.</returns>
    public static string ToKebabCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        return Regex.Replace(input, "([a-z0-9])([A-Z])", "$1-$2").ToLower();
    }

    /// <summary>
    /// /// Converts the specified string to pascal case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The pascal-cased string.</returns>
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var words = Regex.Split(input, @"[\W_]+")
                         .Where(w => !string.IsNullOrEmpty(w))
                         .Select(w => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.ToLower()));

        return string.Concat(words);
    }
}
