using System;

namespace Core.Lib.Utilities;

public sealed class DateUtils
{
    public DateUtils()
    {

    }

    /// <summary>
    /// Combaines date and time from separate DateTime objects into one
    /// </summary>
    /// <param name="date">DateTime object containing date</param>
    /// <param name="time">DateTime object containing time</param>
    public DateTime CombaineDateAndTime(DateTime date, DateTime time)
    {
        return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
    }
}
