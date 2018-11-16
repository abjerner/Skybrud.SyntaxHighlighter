namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    public class JsonToken {

        public JsonTokenType Type { get; internal set; }

        public string Value { get; }

        public JsonToken(JsonTokenType type, string value) {
            Type = type;
            Value = value;
        }

    }

}