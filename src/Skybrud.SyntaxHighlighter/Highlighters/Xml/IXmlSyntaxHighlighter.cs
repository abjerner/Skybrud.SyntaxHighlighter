using System.Xml.Linq;

namespace Skybrud.SyntaxHighlighter.Highlighters.Xml {

    /// <summary>
    /// Interface describing a XML syntax highlighter.
    /// </summary>
    public interface IXmlSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified XML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The XML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightXml(string source);

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightXml(XNode xml);

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <param name="options">The save options to be used when converting <paramref name="xml"/> to string.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightXml(XNode xml, SaveOptions options);

    }

}