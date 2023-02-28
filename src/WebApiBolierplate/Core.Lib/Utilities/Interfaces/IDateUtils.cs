using System;

namespace Core.Lib.Utilities.Interfaces;
public interface IDateUtils
{
    /// <summary>
    /// Combaines date and time from separate DateTime objects into one
    /// </summary>
    /// <param name="date">DateTime object containing date</param>
    /// <param name="time">DateTime object containing time</param>
    public DateTime CombaineDateAndTime(DateTime date, DateTime time);
}
