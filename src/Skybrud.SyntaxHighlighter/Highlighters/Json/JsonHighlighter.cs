using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    internal class JsonHighlighter {

        public string Highlight(string source) {
            List<object> tokens = JsonTokenizer.GetTokens(source ?? "");
            return "<div class=\"highlight json\"><pre>" + ToHtml(tokens) + "</pre></div>";
        }

        private string ToHtml(List<object> list) {
            string temp = "";
            foreach (object obj in list) {
                List<object> sublist = obj as List<object>;
                if (sublist != null) {
                    temp += ToHtml(sublist);
                } else {
                    string str = obj + "";
                    if (str == "null" || str == "false" || str == "true") {
                        temp += "<span class=\"constant\">" + str + "</span>";
                    } else if (Regex.IsMatch(str, "^[0-9]+$")) {
                        temp += "<span class=\"constant\">" + str + "</span>";
                    } else if (Regex.IsMatch(str, "^[0-9]+\\.[0-9]+$")) {
                        temp += "<span class=\"constant\">" + str + "</span>";
                    } else if (str.StartsWith("\"") && str.EndsWith("\"")) {
                        temp += "<span class=\"string\">" + str + "</span>";
                    } else {
                        temp += str;
                    }
                }
            }
            return temp;
        }
    
    }

}