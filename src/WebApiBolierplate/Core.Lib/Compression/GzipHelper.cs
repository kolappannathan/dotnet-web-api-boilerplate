using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Core.Lib.Compression
{
    public class GzipHelper
    {
        public GzipHelper()
        {

        }

        /// <summary>
        /// Compress the given string into a gzip string
        /// </summary>
        /// <param name="s">Uncompressed string</param>
        /// <param name="encoding">Encoding of the string</param>
        /// <returns></returns>
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

        /// <summary>
        /// Decompress a gzip response.
        /// </summary>
        /// <param name="s">Compressed string</param>
        /// <param name="encoding">Encoding of the string</param>
        /// <returns></returns>
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
}
