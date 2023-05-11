using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.SyntaxHighlighter.Highlighters;
using Skybrud.SyntaxHighlighter.Highlighters.CSharp;
using Skybrud.SyntaxHighlighter.Highlighters.Html;
using Skybrud.SyntaxHighlighter.Highlighters.JavaScript;
using Skybrud.SyntaxHighlighter.Highlighters.Json;
using Skybrud.SyntaxHighlighter.Highlighters.Xml;
using System;
using System.Xml.Linq;

namespace Skybrud.SyntaxHighlighter {

    /// <summary>
    /// Static class for accessing a <see cref="ISyntaxHighlighter"/>.
    /// </summary>
    public static class Highlighter {

        /// <summary>
        /// Gets a reference to the current syntax highligther.
        /// </summary>
        /// <remarks>This property provides avaid to access an <see cref="ISyntaxHighlighter"/> in scenarios where
        /// dependency injection isn't set up or can't be used. If you are using dependency injection, it's recommened
        /// adding <see cref="ISyntaxHighlighter"/> to your DI container.</remarks>
        public static ISyntaxHighlighter SyntaxHighlighter { get; } = new Highlighters.SyntaxHighlighter();

        /// <summary>
        /// Highlights the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source / code to be highlighted.</param>
        /// <param name="language">The language to be used.</param>
        /// <returns>The highlighted source.</returns>
        public static string Highlight(string source, Language language) {
            return SyntaxHighlighter?.Highlight(source, language);
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The C# source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightCSharp(string source) {
            return SyntaxHighlighter is not ICSharpSyntaxHighlighter csharp ? GetDefaultBlock(source, "csharp") : csharp.HighlightCSharp(source);
        }

        /// <summary>
        /// Highlights the specified XML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The XML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightXml(string source) {
            return SyntaxHighlighter is not IXmlSyntaxHighlighter xml ? GetDefaultBlock(source, "xml") : xml.HighlightXml(source);
        }

        /// <summary>
        /// Highlights the specified C# XML <paramref name="node"/>.
        /// </summary>
        /// <param name="node">The <see cref="XNode"/> to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightXml(XNode node) {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return HighlightXml(node.ToString());
        }

        /// <summary>
        /// Highlights the specified C# XML <paramref name="node"/>.
        /// </summary>
        /// <param name="node">The <see cref="XNode"/> to be formatted.</param>
        /// <param name="options">The save options to be used when converting <paramref name="node"/> to string.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightXml(XNode node, SaveOptions options) {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return HighlightXml(node.ToString(options));
        }

        /// <summary>
        /// Highlights the specified HTML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The HTML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightHtml(string source) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return SyntaxHighlighter is not IHtmlSyntaxHighlighter html ? GetDefaultBlock(source, "html") : html.HighlightHtml(source);
        }

        /// <summary>
        /// Highlights the specified JavaScript <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JavaScript source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightJavaScript(string source) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return SyntaxHighlighter is not IJavaScriptSyntaxHighlighter js ? GetDefaultBlock(source, "javascript") : js.HighlightJavaScript(source);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightJson(string source) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return SyntaxHighlighter is not IJsonSyntaxHighlighter json ? GetDefaultBlock(source, "json") : json.HighlightJson(source);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightJson(string source, Formatting formatting) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return SyntaxHighlighter is not IJsonSyntaxHighlighter json ? GetDefaultBlock(source, "json") : json.HighlightJson(source, formatting);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightJson(JToken token) {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return SyntaxHighlighter is not IJsonSyntaxHighlighter json ? GetDefaultBlock(token.ToString(), "json") : json.HighlightJson(token);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public static string HighlightJson(JToken token, Formatting formatting) {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return SyntaxHighlighter is not IJsonSyntaxHighlighter json ? GetDefaultBlock(token.ToString(), "json") : json.HighlightJson(token, formatting);
        }

        private static string GetDefaultBlock(string source, string languageName) {
            return $"<div class=\"highlight {languageName}\"><pre>{source}</pre></div>";
        }

    }

}