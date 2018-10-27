using System.Text.RegularExpressions;
using ColorCode;

namespace Skybrud.SyntaxHighlighter.Highlighters.Xml {

    internal class XmlHighlighter {

        public string Highlight(string source) {

            CodeColorizer colorizer = new CodeColorizer();

            string html = colorizer.Colorize(source, Languages.Xml);

            html = html.Replace("<div style=\"color:Black;background-color:White;\">", "<div class=\"highlight xml\">");

            html = html.Replace("<span style=\"color:Blue;\">&lt;?</span>", "&lt;?");
            html = html.Replace("<span style=\"color:Blue;\">?&gt;</span>", "?&gt;");

            html = html.Replace("<span style=\"color:Blue;\">&lt;</span>", "&lt;");
            html = html.Replace("<span style=\"color:Blue;\">&gt;</span>", "&gt;");
            html = html.Replace("<span style=\"color:Blue;\">&lt;/</span>", "&lt;/");

            html = html.Replace("<span style=\"color:Blue;\">&lt;![CDATA[</span>", "<span class=\"cdata\">&lt;![CDATA[</span>");
            html = html.Replace("<span style=\"color:Blue;\">]]&gt;</span>", "<span class=\"cdata\">]]&gt;</span>");

            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"element\">");
            html = html.Replace("<span style=\"color:Red;\">", "<span class=\"attribute\">");
            html = html.Replace("<span style=\"color:Blue;\">", "<span class=\"string\">");
            html = html.Replace("<span style=\"color:Black;\">&quot;</span>", "<span class=\"quot\">&quot;</span>");

            html = html.Replace("<span style=\"color:Green;\">", "<span class=\"comment\">");

            html = Regex.Replace(
                html,
                "(<span class=\"cdata\">&lt;!\\[CDATA\\[</span>)<span style=\"color:Gray;\">(()?(.+?))</span>(<span class=\"cdata\">\\]\\]&gt;</span>)",
                "$1<span class=\"cdatavalue\">$2</span>$5",
                RegexOptions.Singleline
            );

            return html;

        }
    
    }

}