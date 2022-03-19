using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColorCode;

namespace Skybrud.SyntaxHighlighter.Highlighters.JavaScript {

    internal class JavaScriptHighlighter {

        public string Highlight(string source) {

            var formatter = new HtmlFormatter();

            string html = formatter.GetHtmlString(source, Languages.JavaScript);

            html = html.Replace("<div style=\"color:#000000;background-color:#FFFFFF;\">", "<div class=\"highlight javascript\">");

            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"string\">");
            html = html.Replace("<span style=\"color:#0000FF;\">true</span>", "<span class=\"constant\">true</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">false</span>", "<span class=\"constant\">false</span>");
            html = html.Replace("<span style=\"color:#0000FF;\">null</span>", "<span class=\"constant\">null</span>");

            html = html.Replace("<span style=\"color:#0000FF;\">", "<span class=\"keyword\">");

            html = html.Replace("<span style=\"color:#008000;\">", "<span class=\"comment\">");

            return html;



            int offset = 0;

            List<string> tokens = new List<string>();

            html = html.Substring(39, html.Length - 39 - 12);

            while (true) {

                int position = html.IndexOf("<span", offset);

                if (position == -1) {
                    tokens.Add(html.Substring(offset));
                    break;
                }

                int last = html.IndexOf("</span>", position);

                tokens.Add(html.Substring(offset, position - offset));

                tokens.Add(html.Substring(position, last - position + 7));

                offset = last + 7;

            }

            List<string> tokens2 = new List<string>();

            foreach (string token in tokens) {
                
                if (token.StartsWith("<span")) {
                    tokens2.Add(token);
                    continue;
                }

                string t = token;

                //t = t.Replace("===", "<span class=\"operator\">===</span>");
                //t = t.Replace("!==", "<span class=\"operator\">!==</span>");
                //t = t.Replace("==", "<span class=\"operator\">==</span>");
                //t = t.Replace("!=", "<span class=\"operator\">!=</span>");
                //t = t.Replace("=", "<span class=\"operator\">=</span>");

                //tokens2.Add(t);

                int last = 0;

                for (int i = 0; i < token.Length; i++) {

                    char chr = token[i];

                    switch (chr) {
                        case ' ':
                        case '\n':
                        case '\r':
                        case ',':
                        case '[':
                        case ']':
                        case '{':
                        case '}':
                        case '=':
                            string before = token.Substring(last, i - last);
                            if (before.Length > 0) tokens2.Add(before);
                            tokens2.Add(chr + "");
                            last = i + 1;
                            break;
                    }

                }

                string end = token.Substring(last);

                if (end.Length > 0) tokens2.Add(end);

            }


            string temp = "";

            // TODO: tokens3

            for (int i = 0; i < tokens2.Count; i++) {

                string token = tokens2[i];

                if (Next(token, 1, "===")) {
                    
                }

                temp += i + " = --" + HttpUtility.HtmlEncode(tokens2[i].Replace("\n", "\\n").Replace("\r", "\\r")) + "--\n";
            }


            return "<pre>" + temp + "<pre>";

            return HttpUtility.HtmlEncode(html);

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
