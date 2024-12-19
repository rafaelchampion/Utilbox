using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Dates
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

        #region Span Intersection and Comparison Methods

        /// <summary>
        /// Determines if two DatetimeSpans overlap.
        /// </summary>
        /// <param name="span1">The first DatetimeSpan.</param>
        /// <param name="span2">The second DatetimeSpan.</param>
        /// <returns>True if the spans overlap, otherwise false.</returns>
        public static bool Overlaps(DatetimeSpan span1, DatetimeSpan span2)
        {
            return span1.Start < span2.End && span2.Start < span1.End;
        }

        /// <summary>
        /// Gets the intersection of two DatetimeSpans.
        /// </summary>
        /// <param name="span1">The first DatetimeSpan.</param>
        /// <param name="span2">The second DatetimeSpan.</param>
        /// <returns>A DatetimeSpan representing the overlapping period, or null if no overlap.</returns>
        public static DatetimeSpan? GetIntersection(DatetimeSpan span1, DatetimeSpan span2)
        {
            if (!Overlaps(span1, span2))
                return null;

            var start = span1.Start > span2.Start ? span1.Start : span2.Start;
            var end = span1.End < span2.End ? span1.End : span2.End;

            return new DatetimeSpan(start, end);
        }

        /// <summary>
        /// Merges multiple DatetimeSpans into a single continuous span.
        /// </summary>
        /// <param name="spans">Collection of DatetimeSpans to merge.</param>
        /// <returns>A merged DatetimeSpan covering the entire range.</returns>
        public static DatetimeSpan MergeSpans(IEnumerable<DatetimeSpan> spans)
        {
            var datetimeSpans = spans as DatetimeSpan[] ?? spans.ToArray();
            if (spans == null || !datetimeSpans.Any())
                throw new ArgumentException("Cannot merge an empty collection of spans");

            var orderedSpans = datetimeSpans.OrderBy(s => s.Start).ToList();
            var start = orderedSpans.First().Start;
            var end = orderedSpans.Max(s => s.End);

            return new DatetimeSpan(start, end);
        }

        /// <summary>
        /// Splits a DatetimeSpan into equal-sized intervals.
        /// </summary>
        /// <param name="span">The original DatetimeSpan to split.</param>
        /// <param name="intervalCount">Number of intervals to create.</param>
        /// <returns>A collection of DatetimeSpans.</returns>
        public static IEnumerable<DatetimeSpan> SplitSpan(DatetimeSpan span, int intervalCount)
        {
            if (intervalCount <= 0)
                throw new ArgumentException("Interval count must be positive", nameof(intervalCount));

            var totalDuration = span.End - span.Start;
            if (totalDuration.Ticks % intervalCount != 0)
                throw new ArgumentException("The span duration cannot be evenly divided by the interval count.",
                    nameof(intervalCount));
            var intervalDuration = new TimeSpan(totalDuration.Ticks / intervalCount);
            for (var i = 0; i < intervalCount; i++)
            {
                var start = span.Start.AddTicks(intervalDuration.Ticks * i);
                var end = start.Add(intervalDuration);

                yield return new DatetimeSpan(start, end);
            }
        }

        #endregion

        #region Recurring Span Generators

        /// <summary>
        /// Generates recurring daily DatetimeSpans.
        /// </summary>
        /// <param name="startDate">The initial start date.</param>
        /// <param name="count">Number of daily spans to generate.</param>
        /// <param name="isUtc">Whether to use UTC or local time.</param>
        /// <returns>A collection of daily DatetimeSpans.</returns>
        public static IEnumerable<DatetimeSpan> GenerateDailySpans(DateTime startDate, int count, bool isUtc = true)
        {
            for (var i = 0; i < count; i++)
            {
                var currentDate = isUtc
                    ? startDate.AddDays(i).ToUniversalTime()
                    : startDate.AddDays(i);
                yield return new DatetimeSpan(DatetimeHelper.GetStartOfDay(currentDate),
                    DatetimeHelper.GetEndOfDay(currentDate));
            }
        }

        /// <summary>
        /// Generates recurring weekly DatetimeSpans.
        /// </summary>
        /// <param name="startDate">The initial start date.</param>
        /// <param name="count">Number of weekly spans to generate.</param>
        /// <param name="isUtc">Whether to use UTC or local time.</param>
        /// <returns>A collection of weekly DatetimeSpans.</returns>
        public static IEnumerable<DatetimeSpan> GenerateWeeklySpans(DateTime startDate, int count, bool isUtc = true)
        {
            for (var i = 0; i < count; i++)
            {
                var currentDate = isUtc
                    ? startDate.AddWeeks(i).ToUniversalTime()
                    : startDate.AddWeeks(i);
                yield return new DatetimeSpan(DatetimeHelper.GetStartOfWeek(currentDate),
                    DatetimeHelper.GetEndOfWeek(currentDate));
            }
        }

        /// <summary>
        /// Generates recurring monthly DatetimeSpans.
        /// </summary>
        /// <param name="startDate">The initial start date.</param>
        /// <param name="count">Number of monthly spans to generate.</param>
        /// <param name="isUtc">Whether to use UTC or local time.</param>
        /// <returns>A collection of monthly DatetimeSpans.</returns>
        public static IEnumerable<DatetimeSpan> GenerateMonthlySpans(DateTime startDate, int count, bool isUtc = true)
        {
            for (var i = 0; i < count; i++)
            {
                var currentDate = isUtc
                    ? startDate.AddMonths(i).ToUniversalTime()
                    : startDate.AddMonths(i);
                yield return new DatetimeSpan(DatetimeHelper.GetStartOfMonth(currentDate),
                    DatetimeHelper.GetEndOfMonth(currentDate));
            }
        }

        #endregion

        #region Span Duration and Manipulation

        /// <summary>
        /// Calculates the total duration of a DatetimeSpan.
        /// </summary>
        /// <param name="span">The DatetimeSpan to measure.</param>
        /// <returns>A TimeSpan representing the total duration.</returns>
        public static TimeSpan GetDuration(DatetimeSpan span)
        {
            return span.End - span.Start;
        }

        /// <summary>
        /// Extends a DatetimeSpan by a specified duration.
        /// </summary>
        /// <param name="span">The original DatetimeSpan.</param>
        /// <param name="extensionDuration">Duration to extend the span.</param>
        /// <param name="extendEnd">Whether to extend the end (true) or start (false).</param>
        /// <returns>A new extended DatetimeSpan.</returns>
        public static DatetimeSpan ExtendSpan(DatetimeSpan span, TimeSpan extensionDuration, bool extendEnd = true)
        {
            return extendEnd
                ? new DatetimeSpan(span.Start, span.End.Add(extensionDuration))
                : new DatetimeSpan(span.Start.Subtract(extensionDuration), span.End);
        }

        #endregion
    }
}