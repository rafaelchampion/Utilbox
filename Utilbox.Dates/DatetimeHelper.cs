using System;

namespace Utilbox.Dates.DatetimeToolbox.Helpers
{
    public static class DatetimeHelper
    {
        /// <summary>
        /// Gets the start of the day for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the start of the day.</param>
        /// <returns>A DateTime representing the start of the day.</returns>
        public static DateTime GetStartOfDay(DateTime dateTime) => dateTime.Date;

        /// <summary>
        /// Gets the end of the day for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the end of the day.</param>
        /// <returns>A DateTime representing the end of the day.</returns>
        public static DateTime GetEndOfDay(DateTime dateTime) => dateTime.Date.AddDays(1).AddTicks(-1);

        /// <summary>
        /// Gets the start of the week for a given DateTime.
        /// </summary>
        public static DateTime GetStartOfWeek(DateTime dateTime) => dateTime.AddDays(-(int)dateTime.DayOfWeek).Date;

        /// <summary>
        /// Gets the end of the week for a given DateTime.
        /// </summary>
        public static DateTime GetEndOfWeek(DateTime dateTime) => GetStartOfWeek(dateTime).AddDays(7).AddTicks(-1);
        
        /// <summary>
        /// Gets the start of the month for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the start of the month.</param>
        /// <returns>A DateTime representing the start of the month.</returns>
        public static DateTime GetStartOfMonth(DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, 1);

        /// <summary>
        /// Gets the end of the month for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the end of the month.</param>
        /// <returns>A DateTime representing the end of the month.</returns>
        public static DateTime GetEndOfMonth(DateTime dateTime) => GetStartOfMonth(dateTime).AddMonths(1).AddTicks(-1);

        /// <summary>
        /// Gets the start of the year for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the start of the year.</param>
        /// <returns>A DateTime representing the start of the year.</returns>
        public static DateTime GetStartOfYear(DateTime dateTime) => new DateTime(dateTime.Year, 1, 1);

        /// <summary>
        /// Gets the end of the year for a given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the end of the year.</param>
        /// <returns>A DateTime representing the end of the year.</returns>
        public static DateTime GetEndOfYear(DateTime dateTime) => GetStartOfYear(dateTime).AddYears(1).AddTicks(-1);
    }
}