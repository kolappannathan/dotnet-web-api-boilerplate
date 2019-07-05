namespace Core.Constants
{
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

        /// <summary>
        /// Config for database, connection strings, etc...
        /// </summary>
        public static class DataBase
        {
            public static string ConnectionString { get; set; }
        }

        /// <summary>
        /// Config needed for generating and verifying JWT auth token
        /// </summary>
        public static class JWT
        {
            public static string Key;
            public static string Issuer;
            public static string Audience;
            public static int DaysValid;
        }

        public static class Security
        {
            public const string EncryptionKey = "THk5emRHRmphMjkyWlhKbWJHOTNMbU52YlM5eGRXVnpkR2x2Ym5Ndk16azJORGs1TnpZdmFYTXRh";
        }
    }
}
