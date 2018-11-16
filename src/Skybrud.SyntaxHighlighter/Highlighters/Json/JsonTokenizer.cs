using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    public class JsonTokenizer {

        #region Properties

        protected Stack<List<object>> Stack { get; private set; }

        protected List<object> Current => Stack.Peek();

        protected string Buffer { get; private set; }

        #endregion

        #region Constructors

        private JsonTokenizer(string inputText) {

            // Initialize the stack
            Stack = new Stack<List<object>>();

            // Push the root list to the stack
            Stack.Push(new List<object>());

            // Some flags used for the tokenizing
            bool escaped = false;
            bool inquotes = false;
            bool comment = false;

            // Iterate through each character of the string
            foreach (char x in inputText) {
                if (escaped) {
                    Buffer += x;
                    escaped = false;
                } else if (comment) {
                    if (x == '\r' || x == '\n') {
                        PushBuffer();
                        comment = false;
                    }
                    Buffer += x;
                } else {
                    if (!inquotes && x == '/') {
                        PushBuffer();
                        comment = true;
                        Buffer += x;
                    } else if (x == '\\') {
                        Buffer += x;
                        escaped = true;
                    } else if (x == '\"') {
                        Buffer += x;
                        inquotes = !inquotes;
                    } else if (!inquotes) {
                        if (x == ',' || x == ':') {
                            PushBuffer();
                            Buffer += x;
                            PushBuffer();
                        } else if (x == '[' || x == '{') {
                            Buffer += x;
                            PushBuffer();
                            Increment();
                        } else if (x == ']' || x == '}') {
                            PushBuffer();
                            Decrement();
                            Buffer += x;
                        } else {
                            Buffer += x;
                        }
                    } else {
                        Buffer += x;
                    }
                }
            }

            PushBuffer();

        }

        #endregion

        #region Member methods

        void Increment() {
            List<object> list = new List<object>();
            Stack.Peek().Add(list);
            Stack.Push(list);
        }

        void Decrement() {
            Stack.Pop();
        }

        void PushBuffer() {

            if (Buffer == "") return;

            Match match = Regex.Match(Buffer, "^([\\s]+|)(.+?)([\\s]+|)$");

            if (match.Success) {
                if (match.Groups[1].Value != "") Current.Add(match.Groups[1].Value);
                Current.Add(match.Groups[2].Value);
                if (match.Groups[3].Value != "") Current.Add(match.Groups[3].Value);
            } else {
                Current.Add(Buffer);
            }

            Buffer = "";

        }

        #endregion

        #region Static methods

        public static List<object> GetTokens(string str) {
            JsonTokenizer tokenizer = new JsonTokenizer(str);
            return tokenizer.Stack.Peek();
        }

        #endregion

    }

}