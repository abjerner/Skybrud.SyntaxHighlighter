using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.SyntaxHighlighter.Highlighters.CSharp;
using Skybrud.SyntaxHighlighter.Highlighters.Html;
using Skybrud.SyntaxHighlighter.Highlighters.JavaScript;
using Skybrud.SyntaxHighlighter.Highlighters.Json;
using Skybrud.SyntaxHighlighter.Highlighters.Xml;
using System;
using System.Xml.Linq;

namespace Skybrud.SyntaxHighlighter {

    /// <summary>
    /// Default implementation of the <see cref="ISyntaxtHighlighter"/> interface.
    /// </summary>
    public class SyntaxHighlighter : ISyntaxtHighlighter {

        /// <summary>
        /// Highlights the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source / code to be highlighted.</param>
        /// <param name="language">The language to be used.</param>
        /// <returns>The highlighted source.</returns>
        public virtual string Highlight(string source, Language language) {
            return language switch {
                Language.CSharp => HighlightCSharp(source),
                Language.Json => HighlightJson(source),
                Language.JavaScript => HighlightJavaScript(source),
                Language.Html => HighlightHtml(source),
                Language.Xml => HighlightXml(source),
                Language.None => $"<div class=\"highlight\"><pre>{source}</pre></div>",
                _ => $"<div class=\"highlight {language.ToLower()}\"><pre>{source}</pre></div>"
            };
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The C# source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightCSharp(string source) {
            try {
                return new CSharpHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight csharp\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified XML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The XML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightXml(string source) {
            try {
                return new XmlHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight xml\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightXml(XNode xml) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            return HighlightXml(xml.ToString());
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <param name="options">The save options to be used when converting <paramref name="xml"/> to string.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightXml(XNode xml, SaveOptions options) {
            if (xml == null) throw new ArgumentNullException(nameof(xml));
            return HighlightXml(xml.ToString(options));
        }

        /// <summary>
        /// Highlights the specified HTML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The HTML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightHtml(string source) {
            try {
                return new HtmlHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight html\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified JavaScript <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JavaScript source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightJavaScript(string source) {
            try {
                return new JavaScriptHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight javascript\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightJson(string source) {
            try {
                return new JsonHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight json\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightJson(string source, Formatting formatting) {
            try {
                source = JToken.Parse(source).ToString(formatting);
                return new JsonHighlighter().Highlight(source);
            } catch (Exception) {
                return $"<div class=\"highlight json\"><pre>{source}</pre></div>";
            }
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightJson(JToken token) {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return HighlightJson(token.ToString());
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        protected virtual string HighlightJson(JToken token, Formatting formatting) {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return HighlightJson(token.ToString(formatting));
        }

    }

}