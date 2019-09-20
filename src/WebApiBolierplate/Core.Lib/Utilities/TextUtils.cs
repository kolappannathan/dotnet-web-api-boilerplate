namespace Core.Lib.Utilities
{
    public class TextUtils
    {
        #region [Private variables]

        private readonly string lineSeparator = ((char)0x2028).ToString();
        private readonly string paragraphSeparator = ((char)0x2029).ToString();

        #endregion [Private variables]

        public TextUtils()
        {

        }

        #region [Public functions]

        /// <summary>
        /// Removes all line endings such as Line ending, paragraph endings, etc...
        /// Ref: https://stackoverflow.com/a/6765676/5407188
        /// </summary>
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
}
