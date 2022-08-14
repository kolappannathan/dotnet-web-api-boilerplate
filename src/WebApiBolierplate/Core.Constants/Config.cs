namespace Core.Constants;

/// <summary>
/// A class to store config values. Values assigned at startup Avoids reading from config file everytime.
/// </summary>
public static class Config
{
    /// <summary>
    /// Configuration for CSV logger
    /// </summary>
    public static class Logger
    {
        public static string DateFormat { get; set; }
        public static string FileName { get; set; }
        public static string RelativePath { get; set; }
        public static char ReplacementValue { get; set; }
    }
}
