using Core.Lib.Utilities.Interfaces;
using System;

namespace Core.Lib.Utilities;

public sealed class DateUtils: IDateUtils
{
    public DateTime CombaineDateAndTime(DateTime date, DateTime time)
    {
        return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
    }
}
