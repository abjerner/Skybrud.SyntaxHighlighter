using System.Collections.Generic;
using System.Text.RegularExpressions;

#pragma warning disable CS1591

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    /// <summary>
    /// Class reponsible for converting a JSON string into tokens.
    /// </summary>
    public class JsonTokenizer {

        #region Properties

        protected Stack<List<object>> Stack { get; }

        protected List<object> Current => Stack.Peek();

        protected string Buffer { get; private set; }

        protected JsonTokenType Type { get; private set; }

        #endregion

        #region Constructors

        private JsonTokenizer(string inputText) {

            // Initialize the stack
            Stack = new Stack<List<object>>();

            // Push the root list to the stack
            Stack.Push(new List<object>());

            // Some flags used for the tokenizing
            bool escaped = false;

            Type = JsonTokenType.Other;

            // The current character used for string values
            char quote = '"';

            // Iterate through each character of the string
            for (int i = 0; i < inputText.Length; i++) {

                char x = inputText[i];
                char n = i < inputText.Length - 1 ? inputText[i + 1] : (char) 0;

                switch (Type) {

                    case JsonTokenType.String:

                        if (x == quote && !escaped) {
                            Buffer += x;
                            PushBuffer();
                            continue;
                        }

                        escaped = x == '\\';

                        Buffer += x;
                        break;

                    case JsonTokenType.Comment:

                        if (x == '\r' || x == '\n') {
                            PushBuffer();
                            Buffer += x;
                            continue;
                        }

                        Buffer += x;
                        break;

                    case JsonTokenType.BlockComment:

                        if (x == '*' && n == '/') {
                            Buffer += x;
                            Buffer += n;
                            i++;
                            PushBuffer();
                            continue;
                        }

                        Buffer += x;
                        break;

                    default:

                        switch (x) {

                            case '/':
                                PushBuffer();
                                Type = n == '*' ? JsonTokenType.BlockComment : JsonTokenType.Comment;
                                Buffer += x;
                                break;

                            case '"':
                            case '\'':
                                PushBuffer();
                                Type = JsonTokenType.String;
                                Buffer += x;
                                quote = x;
                                break;

                            case '{':
                                PushBuffer();
                                PushBuffer(x, JsonTokenType.ObjectOpen);
                                Increment();
                                break;

                            case '}':
                                PushBuffer();
                                Decrement();
                                PushBuffer(x, JsonTokenType.ObjectClose);
                                break;

                            case '[':
                                PushBuffer();
                                PushBuffer(x, JsonTokenType.ArrayOpen);
                                Increment();
                                break;

                            case ']':
                                PushBuffer();
                                Decrement();
                                PushBuffer(x, JsonTokenType.ArrayClose);
                                break;

                            case ':':
                            case ',':
                                PushBuffer();
                                PushBuffer(x, JsonTokenType.Other);
                                break;

                            default:
                                Buffer += x;
                                break;

                        }

                        break;

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
            PushBuffer(Type);
        }

        void PushBuffer(char chr, JsonTokenType type) {
            PushBuffer(chr + string.Empty, type);
        }

        void PushBuffer(string value, JsonTokenType type) {

            if (string.IsNullOrEmpty(value)) return;

            //if (type == JsonTokenType.Other) {

            //    if (value == "null" || value == "true" || value == "false") {
            //        Current.Add(new JsonToken(JsonTokenType.Constant, value));
            //        Type = JsonTokenType.Other;
            //        return;
            //    }

            //    // TODO: Simplify the four "IsMatch" to a single call

            //    if (Regex.IsMatch(value, "^[0-9]+$")) {
            //        Current.Add(new JsonToken(JsonTokenType.Number, value));
            //        Type = JsonTokenType.Other;
            //        return;
            //    }

            //    if (Regex.IsMatch(value, "^[0-9]+\\.[0-9]+$")) {
            //        Current.Add(new JsonToken(JsonTokenType.Number, value));
            //        Type = JsonTokenType.Other;
            //        return;
            //    }

            //    if (Regex.IsMatch(value, "^-[0-9]+$")) {
            //        Current.Add(new JsonToken(JsonTokenType.Number, value));
            //        Type = JsonTokenType.Other;
            //        return;
            //    }

            //    if (Regex.IsMatch(value, "^-[0-9]+\\.[0-9]+$")) {
            //        Current.Add(new JsonToken(JsonTokenType.Number, value));
            //        Type = JsonTokenType.Other;
            //        return;
            //    }

            //}

            // If the JSON is indented, there will most likely be some whitespace before and/or after the actual value.
            // We can use regular expressions to separate the whitespace from the value :D
            Match match = Regex.Match(value, "^([\\s]+)?(.+?)([\\s]+)?$");

            if (match.Success) {

                // Get the value from the regex
                value = match.Groups[2].Value;

                // Add any whitespace before the value
                if (match.Groups[1].Value != "") Current.Add(new JsonToken(type, match.Groups[1].Value));

                if (value == "null" || value == "true" || value == "false") {
                    Current.Add(new JsonToken(JsonTokenType.Constant, match.Groups[2].Value));
                } else if (Regex.IsMatch(match.Groups[2].Value, "^-?[0-9]+(\\.[0-9]+|)$")) {
                    Current.Add(new JsonToken(JsonTokenType.Number, match.Groups[2].Value));
                } else {
                    Current.Add(new JsonToken(type, value));
                }

                // Add any whitespace after the value
                if (match.Groups[3].Value != "") Current.Add(new JsonToken(type, match.Groups[3].Value));

            } else {

                // Add a new token of "type"
                Current.Add(new JsonToken(type, value));

            }

            Buffer = string.Empty;

            Type = JsonTokenType.Other;

        }

        void PushBuffer(JsonTokenType type) {
            PushBuffer(Buffer, type);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a list of tokens for the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source to be tokenized.</param>
        /// <returns>A list of tokens.</returns>
        public static List<object> GetTokens(string source) {
            JsonTokenizer tokenizer = new JsonTokenizer(source);
            return tokenizer.Stack.Peek();
        }

        #endregion

    }

}