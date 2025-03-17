using System;

namespace Utilbox.Dates;

/// <summary>
/// Represents a range of dates with a start and end date.
/// </summary>
public struct DateRange
{
    /// <summary>
    /// Gets the start date of the range.
    /// </summary>
    public DateTime Start { get; private set; }

    /// <summary>
    /// Gets the end date of the range.
    /// </summary>
    public DateTime End { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateRange"/> struct with the specified start and end dates.
    /// </summary>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <exception cref="ArgumentException">Thrown when the start date is later than the end date.</exception>
    public DateRange(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new ArgumentException("Start date must be before the end date", nameof(start));
        }
        Start = start;
        End = end;
    }
}