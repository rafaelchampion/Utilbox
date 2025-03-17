using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Utilbox.Enums;

public static class EnumUtilities
{
    /// <summary>
    /// Checks if the given integer value is a valid value for the specified enum type.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="value">The integer value to check.</param>
    /// <returns>True if the value is a valid enum value; otherwise, false.</returns>
    public static bool IsValidEnumValue<T>(int value) where T : struct, Enum
    {
        return Enum.IsDefined(typeof(T), value);
    }

    /// <summary>
    /// Returns a list of KeyValuePair where the key is the integer value of the enum and the value is the description attribute.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>A list of KeyValuePair where the key is the enum value and the value is the description.</returns>
    public static ICollection<KeyValuePair<int, string>> GetEnumValuesWithDescriptions<TEnum>() where TEnum : Enum
    {
        var enumType = typeof(TEnum);
        return enumType.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field =>
            {
                var enumValue = (TEnum)field.GetValue(null)!;
                var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
                var description = descriptionAttribute?.Description ?? enumValue.ToString();
                return new KeyValuePair<int, string>(Convert.ToInt32(enumValue), description);
            }).ToList();
    }

    /// <summary>
    /// Gets the enum value based on the display name attribute.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="displayName">The display name attribute of the enum value.</param>
    /// <returns>The enum value that matches the display name.</returns>
    /// <exception cref="ArgumentException">Thrown when the display name is not found.</exception>
    public static TEnum GetEnumByDisplayName<TEnum>(string displayName) where TEnum : Enum
    {
        if (string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentNullException(nameof(displayName));

        var enumType = typeof(TEnum);
        foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null && displayAttribute.Name == displayName)
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new ArgumentException($"Enum with display name '{displayName}' not found in {enumType.Name}.",
            nameof(displayName));
    }

    /// <summary>
    /// Gets the enum value based on the description attribute.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="description">The description attribute of the enum value.</param>
    /// <returns>The enum value that matches the description.</returns>
    /// <exception cref="ArgumentException">Thrown when the description is not found.</exception>
    public static TEnum GetEnumByDescription<TEnum>(string description) where TEnum : Enum
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException(nameof(description));

        var enumType = typeof(TEnum);
        foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null && descriptionAttribute.Description == description)
            {
                return (TEnum)field.GetValue(null)!;
            }
        }
        throw new ArgumentException($"Enum with description '{description}' not found in {enumType.Name}.", nameof(description));
    }

    /// <summary>
    /// Gets the description attribute based on the display name of the enum value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="displayName">The display name of the enum value.</param>
    /// <returns>The description attribute of the enum value, or an empty string if not found.</returns>
    public static string GetDescriptionByDisplayName<TEnum>(string displayName) where TEnum : Enum
    {
        try
        {
            var enumValue = GetEnumByDisplayName<TEnum>(displayName);
            var fieldInfo = typeof(TEnum).GetField(enumValue.ToString());
            if (fieldInfo == null)
                return string.Empty;
            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute?.Description ?? string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Gets all values of an enum type.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>An array of all enum values.</returns>
    public static TEnum[] GetAllValues<TEnum>() where TEnum : Enum
    {
        return (TEnum[])Enum.GetValues(typeof(TEnum));
    }

    /// <summary>
    /// Parses an enum value from a string, with case-insensitive matching.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The string value to parse.</param>
    /// <param name="ignoreCase">Whether to ignore case during parsing.</param>
    /// <returns>The parsed enum value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the value is null or whitespace.</exception>
    public static TEnum ParseEnum<TEnum>(string value, bool ignoreCase = true) where TEnum : Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));
        return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
    }

    /// <summary>
    /// Tries to parse an enum value from a string, with case-insensitive matching.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="value">The string value to parse.</param>
    /// <param name="ignoreCase">Whether to ignore case during parsing.</param>
    /// <param name="result">The parsed enum value, or the default value if parsing fails.</param>
    /// <returns>True if parsing is successful; otherwise, false.</returns>
    public static bool TryParseEnum<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out result);
    }

    /// <summary>
    /// Gets a collection of enum values with their corresponding display names.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>A dictionary of enum values and their display names.</returns>
    public static Dictionary<TEnum, string> GetEnumDisplayNames<TEnum>() where TEnum : Enum
    {
        return GetAllValues<TEnum>()
            .ToDictionary(
                value => value,
                value => value.GetDisplayName()
            );
    }

    /// <summary>
    /// Gets a collection of enum values with their corresponding descriptions.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>A dictionary of enum values and their descriptions.</returns>
    public static Dictionary<TEnum, string> GetEnumDescriptions<TEnum>() where TEnum : Enum
    {
        return GetAllValues<TEnum>()
            .ToDictionary(
                value => value,
                value => value.GetDescription()
            );
    }

    /// <summary>
    /// Combines multiple enum flags.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="flags">The flags to combine.</param>
    /// <returns>A combined enum flag.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the enum type is not marked with the [Flags] attribute.</exception>
    public static TEnum CombineFlags<TEnum>(params TEnum[] flags) where TEnum : Enum
    {
        if (typeof(TEnum).GetCustomAttribute<FlagsAttribute>() == null)
        {
            throw new InvalidOperationException(
                $"Enum {typeof(TEnum).Name} must be marked with [Flags] attribute.");
        }

        var combinedValue = flags.Aggregate(0, (current, flag) => current | Convert.ToInt32(flag));
        return (TEnum)Enum.ToObject(typeof(TEnum), combinedValue);
    }

    /// <summary>
    /// Removes a specific flag from an enum value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The original enum value.</param>
    /// <param name="flagToRemove">The flag to remove.</param>
    /// <returns>An enum value with the specified flag removed.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the enum type is not marked with the [Flags] attribute.</exception>
    public static TEnum RemoveFlag<TEnum>(this TEnum enumValue, TEnum flagToRemove) where TEnum : Enum
    {
        if (typeof(TEnum).GetCustomAttribute<FlagsAttribute>() == null)
        {
            throw new InvalidOperationException(
                $"Enum {typeof(TEnum).Name} must be marked with [Flags] attribute.");
        }

        return (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt32(enumValue) & ~Convert.ToInt32(flagToRemove));
    }
}
