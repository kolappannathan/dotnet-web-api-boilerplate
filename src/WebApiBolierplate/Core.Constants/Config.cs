namespace Core.Constants
{
    public static class Config
    {

        public static class Logger
        {
            public static string DateFormat { get; set; }
            public static string FileName { get; set; }
        }

        public static class DataBase
        {
            public static string ConnectionString { get; set; }
        }

        public static class JWT
        {
            public static string Key;
            public static string Issuer;
            public static string Audience;
        }
    }
}
