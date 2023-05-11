namespace Skybrud.SyntaxHighlighter.Highlighters.JavaScript {

    /// <summary>
    /// Interface describing a JavaScript syntax highlighter.
    /// </summary>
    public interface IJavaScriptSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified JavaScript <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JavaScript source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJavaScript(string source);

    }

}