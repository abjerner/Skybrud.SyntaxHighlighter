namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    /// <summary>
    /// Class describing a JSON token.
    /// </summary>
    public class JsonToken {

        /// <summary>
        /// Gets the type of the token.
        /// </summary>
        public JsonTokenType Type { get; internal set; }

        /// <summary>
        /// Gets the raw value of the token.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initialized a new instanced based on the specified <paramref name="type"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="type">The type of the token.</param>
        /// <param name="value">The value of the token.</param>
        public JsonToken(JsonTokenType type, string value) {
            Type = type;
            Value = value;
        }

    }

}