using System;
using System.Xml.Linq;

namespace Skybrud.SyntaxHighlighter.Highlighters.Xml {

    /// <summary>
    /// XML syntax highligther.
    /// </summary>
    public class XmlSyntaxHighlighter : XmlSyntaxHighlighterBase, IXmlSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(string source) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Highlight(source, "xml");
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(XNode xml) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            return HighlightXml(xml.ToString());
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <param name="options">The save options to be used when converting <paramref name="xml"/> to string.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(XNode xml, SaveOptions options) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            return HighlightXml(xml.ToString(options));
        }

    }

}