using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes.Date
{
    /// <summary>
    /// Sets validation to ensure that date value is greater than today
    /// </summary>
    public class FutureOnlyAttribute : ValidationAttribute
    {
        public FutureOnlyAttribute()
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
