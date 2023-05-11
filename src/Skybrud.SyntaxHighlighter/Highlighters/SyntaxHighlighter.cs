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

namespace Skybrud.SyntaxHighlighter.Highlighters {

    /// <summary>
    /// Default implementation of the <see cref="ISyntaxHighlighter"/> interface.
    /// </summary>
    public class SyntaxHighlighter : ISyntaxHighlighter,
        ICSharpSyntaxHighlighter,
        IHtmlSyntaxHighlighter,
        IJavaScriptSyntaxHighlighter,
        IJsonSyntaxHighlighter,
        IXmlSyntaxHighlighter {

        private ICSharpSyntaxHighlighter _csharp = new CSharpSyntaxHighlighter();
        private IHtmlSyntaxHighlighter _html = new HtmlSyntaxHighlighter();
        private IJavaScriptSyntaxHighlighter _javascript = new JavaScriptSyntaxHighlighter();
        private IJsonSyntaxHighlighter _json = new JsonSyntaxHighlighter();
        private IXmlSyntaxHighlighter _xml = new XmlSyntaxHighlighter();

        #region Properties

        /// <summary>
        /// Gets a reference to the <see cref="ICSharpSyntaxHighlighter"/> to be used internally for this highlighter.
        /// </summary>
        public ICSharpSyntaxHighlighter CSharp {
            get => _csharp;
            set => _csharp = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a reference to the <see cref="IHtmlSyntaxHighlighter"/> to be used internally for this highlighter.
        /// </summary>
        public IHtmlSyntaxHighlighter Html {
            get => _html;
            set => _html = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a reference to the <see cref="IJavaScriptSyntaxHighlighter"/> to be used internally for this highlighter.
        /// </summary>
        public IJavaScriptSyntaxHighlighter JavaScript {
            get => _javascript;
            set => _javascript = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a reference to the <see cref="IJsonSyntaxHighlighter"/> to be used internally for this highlighter.
        /// </summary>
        public IJsonSyntaxHighlighter Json {
            get => _json;
            set => _json = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a reference to the <see cref="IXmlSyntaxHighlighter"/> to be used internally for this highlighter.
        /// </summary>
        public IXmlSyntaxHighlighter Xml {
            get => _xml;
            set => _xml = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

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
        public virtual string HighlightCSharp(string source) {
            return CSharp.HighlightCSharp(source);
        }

        /// <summary>
        /// Highlights the specified XML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The XML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(string source) {
            return Xml.HighlightXml(source);
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(XNode xml) {
            return Xml.HighlightXml(xml);
        }

        /// <summary>
        /// Highlights the specified C# <paramref name="xml"/> node.
        /// </summary>
        /// <param name="xml">The <see cref="XNode"/> to be formatted.</param>
        /// <param name="options">The save options to be used when converting <paramref name="xml"/> to string.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightXml(XNode xml, SaveOptions options) {
            return Xml.HighlightXml(xml, options);
        }

        /// <summary>
        /// Highlights the specified HTML <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The HTML source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightHtml(string source) {
            return Html.HighlightHtml(source);
        }

        /// <summary>
        /// Highlights the specified JavaScript <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JavaScript source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightJavaScript(string source) {
            return JavaScript.HighlightJavaScript(source);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightJson(string source) {
            return Json.HighlightJson(source);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightJson(string source, Formatting formatting) {
            return Json.HighlightJson(source, formatting);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightJson(JToken token) {
            return Json.HighlightJson(token);
        }

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public virtual string HighlightJson(JToken token, Formatting formatting) {
            return Json.HighlightJson(token, formatting);
        }

    }

}