namespace Skybrud.SyntaxHighlighter.Highlighters.Html {

    /// <summary>
    /// Interface describing an HTML syntax highlighter.
    /// </summary>
    public interface IHtmlSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified HTML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The HTML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightHtml(string source);

    }

}