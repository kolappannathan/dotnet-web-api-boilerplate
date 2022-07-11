namespace Core.Constants;

public static class Enums
{
    /// <summary>
    /// Enum for character set
    /// </summary>
    public enum CharSet
    {
        Alphabets, // UPPERCASE, lowercase
        Numbers,
        AlphaNumeric, // UPPERCASE, lowercase and number
        UppercaseOnly,
        LowercaseOnly,
        UppercaseWithNumbers,
        LowercaseWithNumbers
    }
}
