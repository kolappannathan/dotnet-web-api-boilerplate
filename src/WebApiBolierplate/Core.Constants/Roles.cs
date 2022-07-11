namespace Core.Constants;

/// <summary>
/// Contains all the roles of a user
/// </summary>
public static class Roles
{
    public const string Admin = "admin";
    public const string User = "user";
}

/// <summary>
/// Contains roles strings used for auth purporses including combination of roles
/// </summary>
public static class AuthRoles
{
    // adding combained roles for auth
    public const string All = "admin, user";

    // repeating single roles
    public const string Admin = Roles.Admin;
    public const string User = Roles.User;
}
