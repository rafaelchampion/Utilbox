using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Utilbox.Enums
{
    public static class EnumHelper
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
        /// Returns a list of KeyValuePair
        /// where the key is the integer value of the enum and the value is the description attribute.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>A list of KeyValuePair
        ///     where the key is the enum value and the value is the description.
        /// </returns>
        public static ICollection<KeyValuePair<int, string>> GetEnumValuesWithDescriptions<TEnum>() where TEnum : Enum
        {
            var enumType = typeof(TEnum);

            return (from field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static)
                let descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>()
                let enumValue = (TEnum)field.GetValue(null)
                let description = descriptionAttribute?.Description ?? enumValue.ToString()
                select new KeyValuePair<int, string>(Convert.ToInt32(enumValue), description)).ToList();
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
            var enumType = typeof(TEnum);
            foreach (var field in enumType.GetFields())
            {
                var displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null && displayAttribute.Name == displayName)
                {
                    return (TEnum)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Enum with display name '{displayName}' not found in {nameof(TEnum)}.", nameof(displayName));
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
            var enumType = typeof(TEnum);
            foreach (var field in enumType.GetFields())
            {
                var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (descriptionAttribute != null && descriptionAttribute.Description == description)
                {
                    return (TEnum)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Enum with description '{description}' not found in {nameof(TEnum)}.", nameof(description));
        }
        
        /// <summary>
        /// Gets the description attribute based on the display name of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="displayName">The display name of the enum value.</param>
        /// <returns>The description attribute of the enum value, or an empty string if not found.</returns>
        public static string GetDescriptionByDisplayName<TEnum>(string displayName) where TEnum : Enum
        {
            var enumValue = GetEnumByDisplayName<TEnum>(displayName);
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null) return string.Empty;
            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute != null ? descriptionAttribute.Description : string.Empty;
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
        public static TEnum ParseEnum<TEnum>(string value, bool ignoreCase = true) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
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
        public static TEnum CombineFlags<TEnum>(params TEnum[] flags) where TEnum : Enum
        {
            // Ensure the enum is marked with [Flags]
            if (typeof(TEnum).GetCustomAttribute<FlagsAttribute>() == null)
            {
                throw new InvalidOperationException(
                    $"Enum {typeof(TEnum).Name} must be marked with [Flags] attribute.");
            }

            return (TEnum)Enum.ToObject(typeof(TEnum),
                flags.Select(f => Convert.ToInt32(f)).Aggregate((a, b) => a | b));
        }

        /// <summary>
        /// Removes a specific flag from an enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enumValue">The original enum value.</param>
        /// <param name="flagToRemove">The flag to remove.</param>
        /// <returns>An enum value with the specified flag removed.</returns>
        public static TEnum RemoveFlag<TEnum>(this TEnum enumValue, TEnum flagToRemove) where TEnum : Enum
        {
            // Ensure the enum is marked with [Flags]
            if (typeof(TEnum).GetCustomAttribute<FlagsAttribute>() == null)
            {
                throw new InvalidOperationException(
                    $"Enum {typeof(TEnum).Name} must be marked with [Flags] attribute.");
            }

            return (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt32(enumValue) & ~Convert.ToInt32(flagToRemove));
        }
    }
}