namespace Skybrud.SyntaxHighlighter.Highlighters.CSharp {

    /// <summary>
    /// Interface describing a C# syntax highlighter.
    /// </summary>
    public interface ICSharpSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified C# <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The C# source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightCSharp(string source);

    }

}