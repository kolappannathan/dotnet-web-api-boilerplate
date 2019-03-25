using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes
{
    /// <summary>
    /// Similar to <see cref="OnlyFutureAttribute"/> but allows today's date value
    /// </summary>
    public class PresentAndFutureAttribute : ValidationAttribute
    {
        public PresentAndFutureAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var dateValue = Convert.ToDateTime(value);
            var now = DateTime.Now;
            return dateValue >= new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        }
    }
}
