using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    public class JsonTokenizer {

        #region Properties

        protected Stack<List<object>> Stack { get; private set; }

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
            foreach (char x in inputText) {

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

                    default:

                        switch (x) {

                            case '/':
                                PushBuffer();
                                Type = JsonTokenType.Comment;
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
            PushBuffer(chr + String.Empty, type);
        }
        
        void PushBuffer(string value, JsonTokenType type) {
            
            if (String.IsNullOrEmpty(value)) return;

            if (type == JsonTokenType.Other) {

                if (value == "null" || value == "true" || value == "false") {
                    Current.Add(new JsonToken(JsonTokenType.Constant, value));
                    Type = JsonTokenType.Other;
                    return;
                }

                if (Regex.IsMatch(value, "^[0-9]+$")) {
                    Current.Add(new JsonToken(JsonTokenType.Number, value));
                    Type = JsonTokenType.Other;
                    return;
                }

                if (Regex.IsMatch(value, "^[0-9]+\\.[0-9]+$")) {
                    Current.Add(new JsonToken(JsonTokenType.Number, value));
                    Type = JsonTokenType.Other;
                    return;
                }

                if (Regex.IsMatch(value, "^-[0-9]+$")) {
                    Current.Add(new JsonToken(JsonTokenType.Number, value));
                    Type = JsonTokenType.Other;
                    return;
                }

                if (Regex.IsMatch(value, "^-[0-9]+\\.[0-9]+$")) {
                    Current.Add(new JsonToken(JsonTokenType.Number, value));
                    Type = JsonTokenType.Other;
                    return;
                }

            }

            Match match = Regex.Match(value, "^([\\s]+|)(.+?)([\\s]+|)$");

            if (match.Success) {
                if (match.Groups[1].Value != "") Current.Add(new JsonToken(type, match.Groups[1].Value));
                Current.Add(new JsonToken(type, match.Groups[2].Value));
                if (match.Groups[3].Value != "") Current.Add(new JsonToken(type, match.Groups[3].Value));
            } else {
                Current.Add(new JsonToken(type, value));
            }

            Buffer = String.Empty;

            Type = JsonTokenType.Other;

        }

        void PushBuffer(JsonTokenType type) {
            PushBuffer(Buffer, type);
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