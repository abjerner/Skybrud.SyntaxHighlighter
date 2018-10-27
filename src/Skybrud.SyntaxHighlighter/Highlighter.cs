using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ColorCode;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.SyntaxHighlighter.Highlighters.CSharp;
using Skybrud.SyntaxHighlighter.Highlighters.JavaScript;
using Skybrud.SyntaxHighlighter.Highlighters.Json;

namespace Skybrud.SyntaxHighlighter {

    public class Highlighter {

        public static string HighlightCSharp(string source) {
            return new CSharpHighlighter().Highlight(source);
        }

        public static string HighlightXml(string source) {

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

        public static string HighlightXml(XNode xml) {
            if (xml == null) throw new ArgumentNullException("xml");
            return HighlightXml(xml + "");
        }

        public static string HighlightXml(XNode xml, SaveOptions options) {
            if (xml == null) throw new ArgumentNullException("xml");
            return HighlightXml(xml.ToString(options));
        }

        public static string HighlightHtml(string source) {
            return HighlightXml(source);
        }

        public static string HighlightJavaScript(string source) {
            return new JavaScriptHighlighter().Highlight(source);
        }

        public static string HighlightJson(string source) {
            return new JsonHighlighter().Highlight(source);
        }

        public static string HighlightJson(string source, Formatting formatting) {
            source = JToken.Parse(source).ToString(formatting);
            return new JsonHighlighter().Highlight(source);
        }

        public static string HighlightJson(JToken token) {
            if (token == null) throw new ArgumentNullException("token");
            return new JsonHighlighter().Highlight(token + "");
        }

        public static string HighlightJson(JToken token, Formatting formatting) {
            if (token == null) throw new ArgumentNullException("token");
            return new JsonHighlighter().Highlight(token.ToString(formatting));
        }

    }

}