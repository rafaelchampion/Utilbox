using System;
using System.Collections.Generic;

namespace Utilbox.Dates;

public static class DateTimeExtensions
{
    /// <summary>
    /// Adds a specified number of weeks to a DateTime.
    /// </summary>
    /// <param name="dateTime">The original DateTime.</param>
    /// <param name="weeks">Number of weeks to add.</param>
    /// <returns>A new DateTime after adding the specified weeks.</returns>
    public static DateTime AddWeeks(this DateTime dateTime, int weeks)
    {
        return dateTime.AddDays(weeks * 7);
    }

    /// <summary>
    /// Checks if a given date is a holiday.
    /// </summary>
    /// <param name="dateTime">The date to check.</param>
    /// <param name="holidayList">A list of holiday dates.</param>
    /// <returns>True if the date is a holiday, otherwise false.</returns>
    public static bool IsHoliday(this DateTime dateTime, IList<DateTime> holidayList)
    {
        return holidayList?.Contains(dateTime.Date) ?? false;
    }

    /// <summary>
    /// Checks if a given date is a weekend.
    /// </summary>
    /// <param name="dateTime">The date to check.</param>
    /// <returns>True if the date is a Saturday or Sunday, otherwise false.</returns>
    public static bool IsWeekend(this DateTime dateTime)
    {
        return dateTime.DayOfWeek == DayOfWeek.Saturday ||
               dateTime.DayOfWeek == DayOfWeek.Sunday;
    }
}
