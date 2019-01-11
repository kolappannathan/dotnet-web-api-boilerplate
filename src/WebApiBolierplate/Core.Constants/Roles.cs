namespace Core.Constants
{
    public static class Roles
    {
        public const string Admin = "admin";
        public const string User = "user";
    }

    public static class AuthRoles
    {
        // adding combained roles for auth
        public const string All = "admin, user";

        // repeating single roles
        public const string Admin = Roles.Admin;
        public const string User = Roles.User;
    }
}
