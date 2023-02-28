using Core.Lib.Utilities;

namespace Core.Lib;

/// <summary>
/// Helpers wraps up the function in the Core.Library project into a single class
/// </summary>
public class Helpers
{
    #region [Declarations]

    public HashUtils Hash;
    public RandomUtils Rando;
    public GzipUtils GZip;
    public EncryptionUtils Encryption;
    public TextUtils TextUtilities;
    public DateUtils DateLib;

    #endregion [Declarations]

    public Helpers()
    {
        Hash = new HashUtils();
        Encryption = new EncryptionUtils();
        Rando = new RandomUtils();
        GZip = new GzipUtils();
        TextUtilities = new TextUtils();
        DateLib = new DateUtils();
    }

}
