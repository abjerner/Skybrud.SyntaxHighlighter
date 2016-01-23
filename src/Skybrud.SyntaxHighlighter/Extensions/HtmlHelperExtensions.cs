using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.SyntaxHighlighter.Extensions {

    public static class HtmlHelperExtensions {

        public static HtmlString HighlightCSharp(this HtmlHelper helper, string source) {
            return new HtmlString(Highlighter.HighlightCSharp(source));
        }

        public static HtmlString HighlightCSharp<T>(this HtmlHelper<T> helper, string source) {
            return new HtmlString(Highlighter.HighlightCSharp(source));
        }

        public static HtmlString HighlightXml(this HtmlHelper helper, string source) {
            return new HtmlString(Highlighter.HighlightXml(source));
        }

        public static HtmlString HighlightXml<T>(this HtmlHelper<T> helper, string source) {
            return new HtmlString(Highlighter.HighlightXml(source));
        }

        public static HtmlString HighlightXml(this HtmlHelper helper, XNode xml) {
            return new HtmlString(Highlighter.HighlightXml(xml));
        }

        public static HtmlString HighlightXml<T>(this HtmlHelper<T> helper, XNode xml) {
            return new HtmlString(Highlighter.HighlightXml(xml));
        }

        public static HtmlString HighlightXml(this HtmlHelper helper, XNode xml, SaveOptions options) {
            return new HtmlString(Highlighter.HighlightXml(xml, options));
        }

        public static HtmlString HighlightXml<T>(this HtmlHelper<T> helper, XNode xml, SaveOptions options) {
            return new HtmlString(Highlighter.HighlightXml(xml, options));
        }

        public static HtmlString HighlightHtml(this HtmlHelper helper, string source) {
            return new HtmlString(Highlighter.HighlightHtml(source));
        }

        public static HtmlString HighlightHtml<T>(this HtmlHelper<T> helper, string source) {
            return new HtmlString(Highlighter.HighlightHtml(source));
        }

        public static HtmlString HighlightJavaScript(this HtmlHelper helper, string source) {
            return new HtmlString(Highlighter.HighlightJavaScript(source));
        }

        public static HtmlString HighlightJavaScript<T>(this HtmlHelper<T> helper, string source) {
            return new HtmlString(Highlighter.HighlightJavaScript(source));
        }

        public static HtmlString HighlightJson(this HtmlHelper helper, string source) {
            return new HtmlString(Highlighter.HighlightJson(source));
        }

        public static HtmlString HighlightJson<T>(this HtmlHelper<T> helper, string source) {
            return new HtmlString(Highlighter.HighlightJson(source));
        }

        public static HtmlString HighlightJson(this HtmlHelper helper, string source, Formatting formatting) {
            return new HtmlString(Highlighter.HighlightJson(source, formatting));
        }

        public static HtmlString HighlightJson<T>(this HtmlHelper<T> helper, string source, Formatting formatting) {
            return new HtmlString(Highlighter.HighlightJson(source, formatting));
        }

        public static HtmlString HighlightJson(this HtmlHelper helper, JToken token) {
            return new HtmlString(Highlighter.HighlightJson(token));
        }

        public static HtmlString HighlightJson<T>(this HtmlHelper<T> helper, JToken token) {
            return new HtmlString(Highlighter.HighlightJson(token));
        }

        public static HtmlString HighlightJson(this HtmlHelper helper, JToken token, Formatting formatting) {
            return new HtmlString(Highlighter.HighlightJson(token, formatting));
        }

        public static HtmlString HighlightJson<T>(this HtmlHelper<T> helper, JToken token, Formatting formatting) {
            return new HtmlString(Highlighter.HighlightJson(token, formatting));
        }

    }

}