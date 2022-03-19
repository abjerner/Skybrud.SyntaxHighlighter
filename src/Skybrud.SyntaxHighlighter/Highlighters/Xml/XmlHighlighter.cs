using System.Text.RegularExpressions;
using ColorCode;

namespace Skybrud.SyntaxHighlighter.Highlighters.Xml {

    public class XmlHighlighter {

        public virtual string Highlight(string source) {
            return Highlight(source, "xml");
        }

        protected virtual string Highlight(string source, string languageName) {

            var formatter = new HtmlFormatter();

            string html = formatter.GetHtmlString(source, Languages.Xml);

            html = html.Replace("<div style=\"color:#000000;background-color:#FFFFFF;\">", $"<div class=\"highlight {languageName}\">");

            html = html.Replace("<span style=\"color:#0000FF;\">&lt;?</span>", "<span class=\"operator\">&lt;?</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">?&gt;</span>", "<span class=\"operator\">?&gt;</span>");

            html = html.Replace("<span style=\"color:#0000FF;\">&lt;</span>", "<span class=\"operator\">&lt;</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">&gt;</span>", "<span class=\"operator\">&gt;</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">&lt;/</span>", "<span class=\"operator\">&lt;/</span>");

            html = html.Replace("<span style=\"color:#0000FF;\">&lt;![CDATA[</span>", "<span class=\"cdata\">&lt;![CDATA[</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">]]&gt;</span>", "<span class=\"cdata\">]]&gt;</span>");

            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"element\">");
            html = html.Replace("<span style=\"color:#FF0000;\">", "<span class=\"attribute\">");
            html = html.Replace("<span style=\"color:#0000FF;\">", "<span class=\"string\">");
            html = html.Replace("<span style=\"color:#000000;\">&quot;</span>", "<span class=\"quot\">&quot;</span>");

            html = html.Replace("<span class=\"string\">=</span>", "<span class=\"operator\">=</span>");

            html = html.Replace("<span style=\"color:#008000;\">", "<span class=\"comment\">");

            html = Regex.Replace(
                html,
                "(<span class=\"cdata\">&lt;!\\[CDATA\\[</span>)<span style=\"color:#808080;\">(()?(.+?))</span>(<span class=\"cdata\">\\]\\]&gt;</span>)",
                "$1<span class=\"cdatavalue\">$2</span>$5",
                RegexOptions.Singleline
            );

            return html;

        }

    }

}