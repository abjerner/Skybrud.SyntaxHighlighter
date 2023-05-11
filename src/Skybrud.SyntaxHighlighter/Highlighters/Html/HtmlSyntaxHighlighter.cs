using Skybrud.SyntaxHighlighter.Highlighters.Xml;

namespace Skybrud.SyntaxHighlighter.Highlighters.Html {

    /// <summary>
    /// HTML syntax highligther.
    /// </summary>
    public class HtmlSyntaxHighlighter : XmlSyntaxHighlighterBase, IHtmlSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified HTML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The HTML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightHtml(string source) {
            return Highlight(source, "html");
        }

    }

}