using System;

namespace Utilbox.Dates;

public static class DateTimeUtilities
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

    #region Business Day Calculations

    /// <summary>
    /// Gets the next business day from the given DateTime.
    /// </summary>
    /// <param name="dateTime">The starting date to find the next business day.</param>
    /// <returns>The next business day.</returns>
    public static DateTime GetNextBusinessDay(DateTime dateTime)
    {
        var nextDay = dateTime.AddDays(1);
        while (nextDay.IsWeekend())
        {
            nextDay = nextDay.AddDays(1);
        }

        return nextDay;
    }

    /// <summary>
    /// Gets the previous business day from the given DateTime.
    /// </summary>
    /// <param name="dateTime">The starting date to find the previous business day.</param>
    /// <returns>The previous business day.</returns>
    public static DateTime GetPreviousBusinessDay(DateTime dateTime)
    {
        var previousDay = dateTime.AddDays(-1);
        while (previousDay.IsWeekend())
        {
            previousDay = previousDay.AddDays(-1);
        }

        return previousDay;
    }

    /// <summary>
    /// Calculates the number of business days between two dates.
    /// </summary>
    /// <param name="startDate">The start date of the period.</param>
    /// <param name="endDate">The end date of the period.</param>
    /// <returns>The number of business days between the two dates.</returns>
    public static int GetBusinessDaysBetween(DateTime startDate, DateTime endDate)
    {
        var businessDays = 0;
        var currentDate = startDate;

        while (currentDate <= endDate)
        {
            if (!currentDate.IsWeekend())
            {
                businessDays++;
            }

            currentDate = currentDate.AddDays(1);
        }

        return businessDays;
    }

    #endregion

    /// <summary>
    /// Gets the nearest workday to the given date.
    /// </summary>
    /// <param name="dateTime">The date to find the nearest workday for.</param>
    /// <returns>The nearest workday.</returns>
    public static DateTime GetNearestWorkday(DateTime dateTime)
    {
        if (!dateTime.IsWeekend())
            return dateTime;

        var nextDay = dateTime.AddDays(1);
        var previousDay = dateTime.AddDays(-1);

        while (nextDay.IsWeekend() && previousDay.IsWeekend())
        {
            nextDay = nextDay.AddDays(1);
            previousDay = previousDay.AddDays(-1);
        }

        return nextDay.IsWeekend() ? previousDay : nextDay;
    }

    /// <summary>
    /// Calculates the age based on the given birthdate.
    /// </summary>
    /// <param name="birthDate">The date of birth.</param>
    /// <param name="referenceDate">The reference date to calculate the age. Defaults to today.</param>
    /// <returns>The current age in years.</returns>
    public static int GetAge(DateTime birthDate, DateTime? referenceDate = null)
    {
        var today = referenceDate ?? DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (today < birthDate.AddYears(age))
            age--;

        return age;
    }

    /// <summary>
    /// Calculates the exact age with precision to days.
    /// </summary>
    /// <param name="birthDate">The date of birth.</param>
    /// <returns>A TimeSpan representing the exact age.</returns>
    public static TimeSpan GetExactAge(DateTime birthDate)
    {
        return DateTime.Now - birthDate;
    }

    /// <summary>
    /// Calculates the number of workdays in a given period.
    /// </summary>
    /// <param name="startDate">The start date of the period.</param>
    /// <param name="endDate">The end date of the period.</param>
    /// <returns>The number of workdays in the period.</returns>
    public static int GetWorkdaysInPeriod(DateTime startDate, DateTime endDate)
    {
        return GetBusinessDaysBetween(startDate, endDate);
    }
}