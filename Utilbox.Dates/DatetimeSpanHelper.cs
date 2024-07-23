using System;
using Utilbox.Dates.DatetimeToolbox.Classes;

namespace Utilbox.Dates.DatetimeToolbox.Helpers
{
    public static class DatetimeSpanHelper
    {
        /// <summary>
        /// Gets the DatetimeSpan for the current day.
        /// </summary>
        /// <returns>A DatetimeSpan representing the current day.</returns>
        public static DatetimeSpan CurrentDay()
        {
            var now = DateTime.UtcNow;
            return new DatetimeSpan(DatetimeHelper.GetStartOfDay(now), DatetimeHelper.GetEndOfDay(now));
        }
        
        /// <summary>
        /// Gets the DatetimeSpan for the next day.
        /// </summary>
        /// <returns>A DatetimeSpan representing the next day.</returns>
        public static DatetimeSpan NextDay()
        {
            var now = DateTime.UtcNow.AddDays(1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfDay(now), DatetimeHelper.GetEndOfDay(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for the previous day.
        /// </summary>
        /// <returns>A DatetimeSpan representing the previous day.</returns>
        public static DatetimeSpan PreviousDay()
        {
            var now = DateTime.UtcNow.AddDays(-1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfDay(now), DatetimeHelper.GetEndOfDay(now));
        }
        
        /// <summary>
        /// Gets the DatetimeSpan for the current week.
        /// </summary>
        /// <returns>A DatetimeSpan representing the current week.</returns>
        public static DatetimeSpan CurrentWeek()
        {
            var now = DateTime.UtcNow;
            return new DatetimeSpan(DatetimeHelper.GetStartOfWeek(now), DatetimeHelper.GetEndOfWeek(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for the current month.
        /// </summary>
        /// <returns>A DatetimeSpan representing the current month.</returns>
        public static DatetimeSpan CurrentMonth()
        {
            var now = DateTime.UtcNow;
            return new DatetimeSpan(DatetimeHelper.GetStartOfMonth(now), DatetimeHelper.GetEndOfMonth(now));
        }
        
        /// <summary>
        /// Gets the DatetimeSpan for the next month.
        /// </summary>
        /// <returns>A DatetimeSpan representing the next month.</returns>
        public static DatetimeSpan NextMonth()
        {
            var now = DateTime.UtcNow.AddMonths(1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfMonth(now), DatetimeHelper.GetEndOfMonth(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for the previous month.
        /// </summary>
        /// <returns>A DatetimeSpan representing the previous month.</returns>
        public static DatetimeSpan PreviousMonth()
        {
            var now = DateTime.UtcNow.AddMonths(-1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfMonth(now), DatetimeHelper.GetEndOfMonth(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for the current year.
        /// </summary>
        /// <returns>A DatetimeSpan representing the current year.</returns>
        public static DatetimeSpan CurrentYear()
        {
            var now = DateTime.UtcNow;
            return new DatetimeSpan(DatetimeHelper.GetStartOfYear(now), DatetimeHelper.GetEndOfYear(now));
        }
        
        /// <summary>
        /// Gets the DatetimeSpan for the next year.
        /// </summary>
        /// <returns>A DatetimeSpan representing the next year.</returns>
        public static DatetimeSpan NextYear()
        {
            var now = DateTime.UtcNow.AddYears(1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfYear(now), DatetimeHelper.GetEndOfYear(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for the previous year.
        /// </summary>
        /// <returns>A DatetimeSpan representing the previous year.</returns>
        public static DatetimeSpan PreviousYear()
        {
            var now = DateTime.UtcNow.AddYears(-1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfYear(now), DatetimeHelper.GetEndOfYear(now));
        }

        /// <summary>
        /// Gets the DatetimeSpan for a specific month of a specific year.
        /// </summary>
        /// <param name="year">The year of the month.</param>
        /// <param name="month">The month of the year (1-12).</param>
        /// <returns>A DatetimeSpan representing the specified month of the specified year.</returns>
        public static DatetimeSpan MonthOfYear(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfMonth(start), DatetimeHelper.GetEndOfMonth(start));
        }

        /// <summary>
        /// Gets the DatetimeSpan for a specific year.
        /// </summary>
        /// <param name="year">The year to get the DatetimeSpan for.</param>
        /// <returns>A DatetimeSpan representing the specified year.</returns>
        public static DatetimeSpan Year(int year)
        {
            var start = new DateTime(year, 1, 1);
            return new DatetimeSpan(DatetimeHelper.GetStartOfYear(start), DatetimeHelper.GetEndOfYear(start));
        }
    }
}