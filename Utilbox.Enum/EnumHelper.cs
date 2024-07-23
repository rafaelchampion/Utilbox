using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Utilbox.Enum
{
    public static class EnumHelper
    {
        /// <summary>
        /// Checks if the given integer value is a valid value for the specified enum type.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The integer value to check.</param>
        /// <returns>True if the value is a valid enum value; otherwise, false.</returns>
        public static bool IsValidEnumValue<T>(int value) where T : struct, System.Enum
        {
            return System.Enum.IsDefined(typeof(T), value);
        }

        /// <summary>
        /// Returns a list of KeyValuePair
        /// where the key is the integer value of the enum and the value is the description attribute.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>A list of KeyValuePair
        ///     where the key is the enum value and the value is the description.
        /// </returns>
        public static ICollection<KeyValuePair<int, string>> GetEnumValuesWithDescriptions<TEnum>() where TEnum : System.Enum
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
        public static TEnum GetEnumByDisplayName<TEnum>(string displayName) where TEnum : System.Enum
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
        public static TEnum GetEnumByDescription<TEnum>(string description) where TEnum : System.Enum
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
        public static string GetDescriptionByDisplayName<TEnum>(string displayName) where TEnum : System.Enum
        {
            var enumValue = GetEnumByDisplayName<TEnum>(displayName);
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null) return string.Empty;
            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute != null ? descriptionAttribute.Description : string.Empty;
        }
    }
}