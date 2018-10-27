using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ColorCode;

namespace Skybrud.SyntaxHighlighter.Highlighters.CSharp {

    internal class CSharpHighlighter {

        public string Highlight(string source) {

            CodeColorizer colorizer = new CodeColorizer();

            string html = colorizer.Colorize(source, Languages.CSharp);

            html = html.Replace("<div style=\"color:Black;background-color:White;\">", "<div class=\"highlight csharp\">");

            html = html.Replace("<span style=\"color:Blue;\">", "<span class=\"keyword\">");
            html = html.Replace("<span style=\"color:Green;\">", "<span class=\"comment\">");
            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"string\">");

            List<string> lines = new List<string>();

            foreach (string str in html.Split('\n')) {

                string line = str.Replace("\r", "");

                line = Regex.Replace(line, "(<span.+?>(namespace|class)<\\/span>) ([a-zA-Z0-9\\.]+)", "$1 <span class=\"identifier\">$3</span>", RegexOptions.Singleline);
                line = Regex.Replace(line, "(<span.+?>(static|public|private|protected|internal)<\\/span>) ([a-zA-Z0-9\\.]+) ([a-zA-Z0-9\\.]+)", "$1 $3 <span class=\"identifier\">$4</span>", RegexOptions.Singleline);
                line = Regex.Replace(line, "(<span.+?>(static|public|private|protected|internal)<\\/span>) (<span.+?>(void|long|int|bool|float|double)<\\/span>) ([a-zA-Z0-9\\.]+)", "$1 $3 <span class=\"identifier\">$5</span>", RegexOptions.Singleline);

                List<string> tokens = new List<string>();

                foreach (string tkn in GetLineTokens(line)) {

                    string token = tkn;

                    token = token.Replace("<span class=\"keyword\">null</span>", "<span class=\"constant\">null</span>");
                    token = token.Replace("<span class=\"keyword\">true</span>", "<span class=\"constant\">true</span>");
                    token = token.Replace("<span class=\"keyword\">false</span>", "<span class=\"constant\">false</span>");

                    if (Regex.IsMatch(token, "^[0-9]+$")) {
                        token = "<span class=\"constant\">" + token + "</span>";
                    } else if (Regex.IsMatch(token, "^-[0-9]+$")) {
                        token = "<span class=\"constant\">" + token + "</span>";
                    } else if (Regex.IsMatch(token, "^[0-9]+\\.[0-9]+$")) {
                        token = "<span class=\"constant\">" + token + "</span>";
                    } else if (Regex.IsMatch(token, "^-[0-9]+\\.[0-9]+$")) {
                        token = "<span class=\"constant\">" + token + "</span>";
                    }

                    tokens.Add(token);

                }

                line = String.Join("", tokens);

                lines.Add(line);

            }

            html = String.Join("\n", lines);

            return html;

        }

        private bool Next(string line, int offset, string compare) {
            return String.Join("", line.Skip(offset).Take(compare.Length)) == compare;
        }

        private string[] GetLineTokens(string line) {

            List<string> tokens = new List<string>();

            string type = "";
            string hai = "";

            for (int i = 0; i < line.Length; i++) {
                char chr = line[i];

                if (Next(line, i, "<span") && type != "string") {
                    if (hai.Length > 0) tokens.Add(hai);
                    int pos = line.IndexOf("</span>", i, StringComparison.Ordinal);
                    int length = pos + 7 - i;
                    tokens.Add(line.Substring(i, length));
                    hai = ""; type = "";
                    i += length - 1;
                } else if (Next(line, i, "<span") && type != "string") {
                    if (hai.Length > 0) {
                        tokens.Add(hai);
                    }
                    int pos = line.IndexOf("</span>", i, StringComparison.Ordinal);
                    int length = pos + 7 - i;
                    tokens.Add(line.Substring(i, length));
                    hai = "";
                    type = "";
                    i += length - 1;
                } else if (chr == ',' || chr == '(' || chr == ')' || chr == '|' || chr == '[' || chr == ']' || chr == ' ' || chr == ';' || chr == '=') {
                    if (hai.Length > 0) tokens.Add(hai);
                    tokens.Add(chr + "");
                    hai = ""; type = "";
                } else {
                    hai += chr;
                }

            }

            tokens.Add(hai);

            return tokens.ToArray();

        }
    
    }

}