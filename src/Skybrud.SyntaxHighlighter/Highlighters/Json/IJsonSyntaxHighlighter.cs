using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.SyntaxHighlighter.Highlighters.Json {
    
    /// <summary>
    /// Interface describing a JSON syntax highlighter.
    /// </summary>
    public interface IJsonSyntaxHighlighter {

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJson(string source);

        /// <summary>
        /// Highlights the specified JSON <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The JSON source code to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJson(string source, Formatting formatting);

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJson(JToken token);

        /// <summary>
        /// Highlights the specified JSON <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The JSON token to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The HTML with the formatted code.</returns>
        public string HighlightJson(JToken token, Formatting formatting);

    }

}