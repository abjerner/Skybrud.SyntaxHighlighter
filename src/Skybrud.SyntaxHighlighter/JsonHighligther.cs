using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode;

namespace Skybrud.SyntaxHighlighter {

    internal class JsonHighlighter {

        public string Highlight(string source) {
            
            CodeColorizer colorizer = new CodeColorizer();
            string html = colorizer.Colorize(source, Languages.JavaScript);

            html = html.Replace("<div style=\"color:Black;background-color:White;\">", "<div class=\"highlight json\">");

            html = html.Replace("<span style=\"color:#A31515;\">", "<span class=\"string\">");

            try {

                List<string> list = new List<string>();

                int last = 0;

                while (true) {

                    int pos1 = html.IndexOf("<span", last, StringComparison.InvariantCulture);
                    if (pos1 == -1) { break; }

                    int pos2 = html.IndexOf("</span>", pos1, StringComparison.InvariantCulture);
                    if (pos2 == -1) { break; }
                    pos2 += 7;

                    list.Add(html.Substring(last, pos1 - last));
                    list.Add(html.Substring(pos1, pos2 - pos1));

                    last = pos2;

                }

                list.Add(html.Substring(last));

                List<string> bacon = new List<string>();

                foreach (string piece in list) {
                    if (piece.StartsWith("<span")) {
                        bacon.Add(piece);
                    } else {
                        string blah = piece;
                        blah = Regex.Replace(blah, "([0-9]+)", "<span class=\"constant\">$1</span>");
                        blah = Regex.Replace(blah, "([0-9]\\[0-9].+)", "<span class=\"constant\">$1</span>");
                        blah = Regex.Replace(blah, "(false|true|null)", "<span class=\"constant\">$1</span>");
                        bacon.Add(blah);
                    }
                }

                return String.Join("", bacon);

            } catch (Exception) {

                return html;
            
            }

        }
    
    }

}