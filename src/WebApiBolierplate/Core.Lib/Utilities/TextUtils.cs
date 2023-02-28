using Core.Lib.Utilities.Interfaces;

namespace Core.Lib.Utilities;

public sealed class TextUtils: ITextUtils
{
    #region [Private variables]

    private readonly string lineSeparator = ((char)0x2028).ToString();
    private readonly string paragraphSeparator = ((char)0x2029).ToString();

    #endregion [Private variables]

    #region [Public functions]

    public string RemoveLineEndings(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return text.Replace("\r\n", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace(lineSeparator, string.Empty)
                    .Replace(paragraphSeparator, string.Empty);
    }

    #endregion [Public functions]
}
