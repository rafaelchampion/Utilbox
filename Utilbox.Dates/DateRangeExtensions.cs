using System;
using System.Collections.Generic;

namespace Utilbox.Dates;

public static class DateRangeExtensions
{
    /// <summary>
    /// Determines whether two <see cref="DateRange"/>s overlap.
    /// </summary>
    /// <param name="range">The first date range.</param>
    /// <param name="targetRange">The second date range.</param>
    /// <returns><c>true</c> if the date ranges overlap; otherwise, <c>false</c>.</returns>
    public static bool Overlaps(this DateRange range, DateRange targetRange)
    {
        return range.Start < targetRange.End && targetRange.Start < range.End;
    }

    /// <summary>
    /// Gets the intersection of two overlapping <see cref="DateRange"/>s.
    /// </summary>
    /// <param name="range">The first date range.</param>
    /// <param name="targetRange">The second date range.</param>
    /// <returns>A <see cref="DateRange"/> representing the intersection of the two date ranges, or <c>null</c> if they do not overlap.</returns>
    public static DateRange? GetIntersection(this DateRange range, DateRange targetRange)
    {
        if (!range.Overlaps(targetRange))
            return null;

        var start = range.Start > targetRange.Start ? range.Start : targetRange.Start;
        var end = range.End < targetRange.End ? range.End : targetRange.End;
        return new DateRange(start, end);
    }

    /// <summary>
    /// Gets the duration of the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>A <see cref="TimeSpan"/> representing the duration of the date range.</returns>
    public static TimeSpan GetDuration(this DateRange range)
    {
        return range.End - range.Start;
    }

    /// <summary>
    /// Gets the total number of full days in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>The number of full days in the range.</returns>
    public static int GetDays(this DateRange range)
    {
        return (int)(range.End - range.Start).TotalDays;
    }

    /// <summary>
    /// Gets the total number of full weeks in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>The number of full weeks in the range.</returns>
    public static int GetWeeks(this DateRange range)
    {
        return (int)(range.End - range.Start).TotalDays / 7;
    }

    /// <summary>
    /// Gets the total number of full months in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>The number of months in the range.</returns>
    public static int GetMonths(this DateRange range)
    {
        return ((range.End.Year - range.Start.Year) * 12) + range.End.Month - range.Start.Month;
    }

    /// <summary>
    /// Gets the total number of full years in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>The number of years in the range.</returns>
    public static int GetYears(this DateRange range)
    {
        return range.End.Year - range.Start.Year;
    }

    /// <summary>
    /// Gets the exact number of days in the date range, including fractional days.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>The exact number of days as a decimal value.</returns>
    public static double GetExactDays(this DateRange range)
    {
        return (range.End - range.Start).TotalDays;
    }

    /// <summary>
    /// Gets all calendar days included in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects representing each day in the range.</returns>
    public static IEnumerable<DateTime> EnumerateDays(this DateRange range)
    {
        for (var day = range.Start.Date; day <= range.End.Date; day = day.AddDays(1))
        {
            yield return day;
        }
    }

    /// <summary>
    /// Gets all calendar months included in the date range.
    /// </summary>
    /// <param name="range">The date range.</param>
    /// <returns>An enumerable collection of <see cref="DateRange"/> objects representing each month in the range.</returns>
    public static IEnumerable<DateRange> EnumerateMonths(this DateRange range)
    {
        // If the provided end has a time of 00:00:00, assume the full day is included.
        var effectiveRangeEnd = range.End;
        if (range.End.TimeOfDay == TimeSpan.Zero)
        {
            effectiveRangeEnd = new DateTime(range.End.Year, range.End.Month, range.End.Day, 23, 59, 59, 999);
        }

        var currentMonth = new DateTime(range.Start.Year, range.Start.Month, 1);

        while (currentMonth <= effectiveRangeEnd)
        {
            var daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            var monthEndCalculated = new DateTime(
                currentMonth.Year,
                currentMonth.Month,
                daysInMonth,
                23, 59, 59, 999);

            yield return new DateRange(
                currentMonth < range.Start ? range.Start : currentMonth,
                monthEndCalculated > effectiveRangeEnd ? effectiveRangeEnd : monthEndCalculated
            );

            currentMonth = currentMonth.AddMonths(1);
        }
    }

    /// <summary>
    /// Extends the date range by a specified duration.
    /// </summary>
    /// <param name="span">The date range to extend.</param>
    /// <param name="extensionDuration">The duration to extend the date range by.</param>
    /// <param name="extendEnd">If <c>true</c>, extends the end date; otherwise, extends the start date.</param>
    /// <returns>A new <see cref="DateRange"/> with the extended duration.</returns>
    public static DateRange ExtendSpan(this DateRange span, TimeSpan extensionDuration, bool extendEnd = true)
    {
        return extendEnd
            ? new DateRange(span.Start, span.End.Add(extensionDuration))
            : new DateRange(span.Start.Subtract(extensionDuration), span.End);
    }
}