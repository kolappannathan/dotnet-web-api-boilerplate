using Core.Lib.Compression;
using Core.Lib.Security;
using Core.Lib.Utilities;

namespace Core.Lib
{
    /// <summary>
    /// Helpers wraps up the function in the Core.Library project into a single class
    /// </summary>
    public class Helpers
    {
        #region [Declarations]

        public HashHelper Hash;
        public RandoLib Rando;
        public GzipHelper GZip;
        public EncryptionHelper Encryption;

        #endregion [Declarations]

        public Helpers()
        {
            Hash = new HashHelper();
            Encryption = new EncryptionHelper();
            Rando = new RandoLib();
            GZip = new GzipHelper();
        }

    }
}
