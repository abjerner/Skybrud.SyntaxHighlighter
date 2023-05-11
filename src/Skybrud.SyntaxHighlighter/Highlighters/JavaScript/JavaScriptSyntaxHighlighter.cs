using ColorCode;
using System;

namespace Skybrud.SyntaxHighlighter.Highlighters.JavaScript {

    /// <summary>
    /// JavaScript syntax highligther.
    /// </summary>
    public class JavaScriptSyntaxHighlighter : IJavaScriptSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified JavaScript <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JavaScript source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJavaScript(string source) {

            try {

                string html = new HtmlFormatter().GetHtmlString(source, Languages.JavaScript);

                html = html.Replace("<div style=\"color:#000000;background-color:#FFFFFF;\">", "<div class=\"highlight javascript\">");
                html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"string\">");
                html = html.Replace("<span style=\"color:#0000FF;\">true</span>", "<span class=\"constant\">true</span>");
                html = html.Replace("<span style=\"color:#0000FF;\">false</span>", "<span class=\"constant\">false</span>");
                html = html.Replace("<span style=\"color:#0000FF;\">null</span>", "<span class=\"constant\">null</span>");
                html = html.Replace("<span style=\"color:#0000FF;\">", "<span class=\"keyword\">");
                html = html.Replace("<span style=\"color:#008000;\">", "<span class=\"comment\">");

                return html;

            } catch (Exception) {
                
                return $"<div class=\"highlight javascript\"><pre>{source}</pre></div>";

            }

        }

    }

}