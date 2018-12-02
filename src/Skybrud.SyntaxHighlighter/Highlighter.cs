using System;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.SyntaxHighlighter.Highlighters.CSharp;
using Skybrud.SyntaxHighlighter.Highlighters.JavaScript;
using Skybrud.SyntaxHighlighter.Highlighters.Json;
using Skybrud.SyntaxHighlighter.Highlighters.Xml;

namespace Skybrud.SyntaxHighlighter {

    public class Highlighter {
        
        /// <summary>
        /// Highlights the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source / code to be highlighted.</param>
        /// <param name="language">The language to be used.</param>
        /// <returns>The highlighted source.</returns>
        public static string Highlight(string source, Language language) {

            try {

                switch (language) {

                    case Language.CSharp:
                        return HighlightCSharp(source);

                    case Language.Json:
                        return HighlightJson(source);

                    case Language.JavaScript:
                        return HighlightJavaScript(source);

                    case Language.Html:
                        return HighlightHtml(source);

                    case Language.Xml:
                        return HighlightXml(source);

                    default:
                        return "<div class=\"highlight\"><pre>" + source + "</pre></div>";

                }

            } catch (Exception) {

                return "<div class=\"highlight\"><pre>" + source + "</pre></div>";

            }

        }

        public static string HighlightCSharp(string source) {
            return new CSharpHighlighter().Highlight(source);
        }

        public static string HighlightXml(string source) {
            return new XmlHighlighter().Highlight(source);
        }

        public static string HighlightXml(XNode xml) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            return HighlightXml(xml + "");
        }

        public static string HighlightXml(XNode xml, SaveOptions options) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
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
            if (token == null) throw new ArgumentNullException(nameof(token));
            return new JsonHighlighter().Highlight(token + "");
        }

        public static string HighlightJson(JToken token, Formatting formatting) {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return new JsonHighlighter().Highlight(token.ToString(formatting));
        }

    }

}