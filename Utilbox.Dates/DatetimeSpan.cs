using System;

namespace Utilbox.Dates.DatetimeToolbox.Classes
{
    public struct DatetimeSpan
    {
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public DatetimeSpan(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime > endDateTime)
            {
                throw new ArgumentException("Start date must be before the end date", nameof(startDateTime));
            }
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}