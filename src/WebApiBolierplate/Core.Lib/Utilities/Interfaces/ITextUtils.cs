namespace Core.Lib.Utilities.Interfaces;
public interface ITextUtils
{
    /// <summary>
    /// Removes all line endings such as Line ending, paragraph endings, etc...
    /// Ref: https://stackoverflow.com/a/6765676/5407188
    /// </summary>
    public string RemoveLineEndings(string text);
}
