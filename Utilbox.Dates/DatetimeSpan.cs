using System;

namespace Utilbox.Dates
{
    public struct DatetimeSpan
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public DatetimeSpan(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start date must be before the end date", nameof(start));
            }
            Start = start;
            End = end;
        }
    }
}