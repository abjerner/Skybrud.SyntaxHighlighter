using ColorCode;

namespace Skybrud.SyntaxHighlighter.Highlighters.JavaScript {

    internal class JavaScriptHighlighter {

        public string Highlight(string source) {

            var formatter = new HtmlFormatter();

            string html = formatter.GetHtmlString(source, Languages.JavaScript);

            html = html.Replace("<div style=\"color:#000000;background-color:#FFFFFF;\">", "<div class=\"highlight javascript\">");

            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"string\">");
            html = html.Replace("<span style=\"color:#0000FF;\">true</span>", "<span class=\"constant\">true</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">false</span>", "<span class=\"constant\">false</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">null</span>", "<span class=\"constant\">null</span>");

            html = html.Replace("<span style=\"color:#0000FF;\">", "<span class=\"keyword\">");

            html = html.Replace("<span style=\"color:#008000;\">", "<span class=\"comment\">");

            return html;

        }
    
    }

}
