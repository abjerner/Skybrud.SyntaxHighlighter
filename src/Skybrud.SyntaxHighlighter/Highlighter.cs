namespace Skybrud.SyntaxHighlighter {

    /// <summary>
    /// Static class for accessing a <see cref="ISyntaxtHighlighter"/>.
    /// </summary>
    public static class Highlighter {

        /// <summary>
        /// Gets a reference to the current syntax highligther.
        /// </summary>
        /// <remarks>This property provides avaid to access an <see cref="ISyntaxtHighlighter"/> in scenarios where
        /// dependency injection isn't set up or can't be used. If you are using dependency injection, it's recommened
        /// adding <see cref="ISyntaxtHighlighter"/> to your DI container.</remarks>
        public static ISyntaxtHighlighter SyntaxtHighlighter { get; } = new SyntaxHighlighter();

        /// <summary>
        /// Highlights the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source / code to be highlighted.</param>
        /// <param name="language">The language to be used.</param>
        /// <returns>The highlighted source.</returns>
        public static string Highlight(string source, Language language) {
            return SyntaxtHighlighter?.Highlight(source, language);
        }

    }

}