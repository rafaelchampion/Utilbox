using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Utilbox.Enum
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the display name of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The display name of the enum value if found; otherwise, the enum value as a string.</returns>
        public static string GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : System.Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var displayAttribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
            return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }

        /// <summary>
        /// Gets the description of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The description of the enum value if found; otherwise, the enum value as a string.</returns>
        public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : System.Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute != null ? descriptionAttribute.Description : enumValue.ToString();
        }
    }
}