using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Lib.Utilities.Interfaces;
public interface IGzipUtils
{
    /// <summary>
    /// Compress the given string into a gzip string
    /// </summary>
    /// <param name="s">Uncompressed string</param>
    /// <param name="encoding">Encoding of the string</param>
    /// <returns></returns>
    public string CompressToString(string s, Encoding encoding);

    /// <summary>
    /// Decompress a gzip response.
    /// </summary>
    /// <param name="s">Compressed string</param>
    /// <param name="encoding">Encoding of the string</param>
    /// <returns></returns>
    public string DecompressString(string s, Encoding encoding);
}
