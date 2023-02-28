using Core.Lib.Utilities.Interfaces;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Core.Lib.Utilities;

public sealed class GzipUtils : IGzipUtils
{
    public string CompressToString(string s, Encoding encoding)
    {
        var bytes = encoding.GetBytes(s);
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                msi.CopyTo(gs);
            }
            return Convert.ToBase64String(mso.ToArray());
        }
    }

    public string DecompressString(string s, Encoding encoding)
    {
        var bytes = Convert.FromBase64String(s);
        using (var msi = new MemoryStream(bytes))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }
            return encoding.GetString(mso.ToArray());
        }
    }
}
