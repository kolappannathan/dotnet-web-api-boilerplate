using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes
{
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
