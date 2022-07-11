using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes;

/// <summary>
/// Used to set minimum value validation for int, long and double values
/// </summary>
public class MinValueAttribute : ValidationAttribute
{
    private long Minimum { get; set; }

    public MinValueAttribute(long minimum)
    {
        Minimum = minimum;
    }

    public override bool IsValid(object value)
    {
        return Convert.ToInt64(value) >= Minimum;
    }
}
