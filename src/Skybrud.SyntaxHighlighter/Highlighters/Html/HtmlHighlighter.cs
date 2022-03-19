using Skybrud.SyntaxHighlighter.Highlighters.Xml;

namespace Skybrud.SyntaxHighlighter.Highlighters.Html {

    public class HtmlHighlighter : XmlHighlighter {

        public override string Highlight(string source) {
            return Highlight(source, "html");
        }

    }

}