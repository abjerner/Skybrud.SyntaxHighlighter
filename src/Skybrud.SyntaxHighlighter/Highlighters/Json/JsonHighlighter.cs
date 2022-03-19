using System.Collections.Generic;
using System.Web;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    /// <summary>
    /// JSON syntax highligther.
    /// </summary>
    public class JsonHighlighter {

        /// <summary>
        /// Highlights the specified JSON string.
        /// </summary>
        /// <param name="str">The JSON strin to be highlighted.</param>
        /// <returns>The highlighted JSON string.</returns>
        public virtual string Highlight(string str) {
            List<object> tokens = JsonTokenizer.GetTokens(str ?? string.Empty);
            return $"<div class=\"highlight json\"><pre>{ToHtml(tokens)}</pre></div>";
        }

        /// <summary>
        /// Converts a list of tokens into the highlighted HTML.
        /// </summary>
        /// <param name="list">The list of tokens.</param>
        /// <returns>The generated HTML.</returns>
        protected virtual string ToHtml(List<object> list) {

            string temp = "";

            foreach (object obj in list) {

                switch (obj) {

                    case List<object> sublist:
                        temp += ToHtml(sublist);
                        break;

                    case JsonToken token:
                        temp += ToHtml(token);
                        break;

                }

            }

            return temp;

        }

        /// <summary>
        /// Converts the specified <paramref name="token"/> to HTML.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>The HTML representation of <paramref name="token"/>.</returns>
        protected virtual string ToHtml(JsonToken token) {

            switch (token.Type) {

                case JsonTokenType.String:
                    return RenderString(token.Value);

                case JsonTokenType.Comment:
                case JsonTokenType.BlockComment:
                    return RenderComment(token.Value);

                case JsonTokenType.Constant:
                    return RenderConstant(token.Value);

                case JsonTokenType.Number:
                    return RenderNumber(token.Value);

                default:
                    return HttpUtility.HtmlEncode(token.Value);

            }

        }

        /// <summary>
        /// Renders the HTML for a JSON constant.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        /// <returns>The HTML representing the constant.</returns>
        protected virtual string RenderConstant(string value) {
            return $"<span class=\"constant\">{value}</span>";
        }

        /// <summary>
        /// Renders the HTML for a JSON number.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns>The HTML representing the number.</returns>
        protected virtual string RenderNumber(string value) {
            return $"<span class=\"constant\">{value}</span>";
        }

        /// <summary>
        /// Renders the HTML for a JSON string.
        /// </summary>
        /// <param name="value">The value of the string.</param>
        /// <returns>The HTML representing the string.</returns>
        protected virtual string RenderString(string value) {
            return $"<span class=\"string\">{HttpUtility.HtmlEncode(value)}</span>";
        }

        /// <summary>
        /// Renders the HTML for a JSON comment.
        /// </summary>
        /// <param name="value">The value of the comment.</param>
        /// <returns>The HTML representing the comment.</returns>
        protected virtual string RenderComment(string value) {
            return $"<span class=\"comment\">{HttpUtility.HtmlEncode(value)}</span>";
        }

    }

}