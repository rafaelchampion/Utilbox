using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Utilbox.Enums;

public static class EnumExtensions
{
    private static readonly ConcurrentDictionary<FieldInfo, DisplayAttribute> DisplayAttributeCache = new();
    private static readonly ConcurrentDictionary<FieldInfo, DescriptionAttribute?> DescriptionAttributeCache = new();
    
    /// <summary>
    /// Gets the display name of the enum value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value.</param>
    /// <returns>The display name of the enum value if found; otherwise, the enum value as a string.</returns>
    public static string GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        if (fieldInfo == null) return enumValue.ToString();

        var displayAttribute = DisplayAttributeCache.GetOrAdd(fieldInfo,
            fi => fi.GetCustomAttribute<DisplayAttribute>());
        return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
    }

    /// <summary>
    /// Gets the description of the enum value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value.</param>
    /// <returns>The description of the enum value if found; otherwise, the enum value as a string.</returns>
    public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        if (fieldInfo == null) return enumValue.ToString();

        var descriptionAttribute = DescriptionAttributeCache.GetOrAdd(fieldInfo,
            fi => fi.GetCustomAttribute<DescriptionAttribute>());
        return descriptionAttribute != null ? descriptionAttribute.Description : enumValue.ToString();
    }

    /// <summary>
    /// Converts an enum value to its corresponding integer value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value to convert.</param>
    /// <returns>The integer representation of the enum value.</returns>
    public static int ToInt<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        return Convert.ToInt32(enumValue);
    }

    /// <summary>
    /// Determines if the current enum value has a specific flag set.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value to check.</param>
    /// <param name="flag">The flag to check for.</param>
    /// <returns>True if the flag is set, otherwise false.</returns>
    public static bool HasFlagCustom<TEnum>(this TEnum enumValue, TEnum flag) where TEnum : Enum
    {
        return typeof(TEnum).GetCustomAttribute<FlagsAttribute>() != null
            ? enumValue.HasFlag(flag)
            : enumValue.Equals(flag);
    }
}