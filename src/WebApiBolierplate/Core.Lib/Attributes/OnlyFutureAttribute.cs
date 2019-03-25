using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes
{
    /// <summary>
    /// Sets validation to ensure that date value is greater than today
    /// </summary>
    public class OnlyFutureAttribute : ValidationAttribute
    {
        public OnlyFutureAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var dateValue = Convert.ToDateTime(value);
            return dateValue >= DateTime.Now;
        }
    }
}
