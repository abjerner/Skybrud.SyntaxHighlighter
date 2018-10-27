using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    public class JsonHighlighter {

        /// <summary>
        /// Highlights the specified JSON string.
        /// </summary>
        /// <param name="str">The JSON strin to be highlighted.</param>
        /// <returns>The highlighted JSON string.</returns>
        public virtual string Highlight(string str) {
            List<object> tokens = JsonTokenizer.GetTokens(str ?? "");
            return "<div class=\"highlight json\"><pre>" + ToHtml(tokens) + "</pre></div>";
        }

        /// <summary>
        /// Converts a list of tokens into the highlighted HTML.
        /// </summary>
        /// <param name="list">The list of tokens.</param>
        /// <returns>Returns the generated HTML.</returns>
        protected virtual string ToHtml(List<object> list) {
            string temp = "";
            foreach (object obj in list) {
                List<object> sublist = obj as List<object>;
                if (sublist != null) {
                    temp += ToHtml(sublist);
                } else {
                    string str = obj + "";
                    if (str == "null" || str == "false" || str == "true") {
                        temp += RenderConstant(str);
                    } else if (Regex.IsMatch(str, "^[0-9]+$")) {
                        temp += RenderNumber(str);
                    } else if (Regex.IsMatch(str, "^[0-9]+\\.[0-9]+$")) {
                        temp += RenderNumber(str);
                    } else if (Regex.IsMatch(str, "^-[0-9]+$")) {
                        temp += RenderNumber(str);
                    } else if (Regex.IsMatch(str, "^-[0-9]+\\.[0-9]+$")) {
                        temp += RenderNumber(str);
                    } else if (str.StartsWith("\"") && str.EndsWith("\"")) {
                        temp += RenderString(str);
                    } else {
                        temp += str;
                    }
                }
            }
            return temp;
        }

        /// <summary>
        /// Renders the HTML for a JSON constant.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        /// <returns>Returns the HTML representing the constant.</returns>
        protected virtual string RenderConstant(string value) {
            return "<span class=\"constant\">" + value + "</span>";
        }

        /// <summary>
        /// Renders the HTML for a JSON number.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns>Returns the HTML representing the number.</returns>
        protected virtual string RenderNumber(string value) {
            return "<span class=\"constant\">" + value + "</span>";
        }

        /// <summary>
        /// Renders the HTML for a JSON string.
        /// </summary>
        /// <param name="value">The value of the string.</param>
        /// <returns>Returns the HTML representing the string.</returns>
        protected virtual string RenderString(string value) {
            return "<span class=\"string\">" + HttpUtility.HtmlEncode(value) + "</span>";
        }
    
    }

}