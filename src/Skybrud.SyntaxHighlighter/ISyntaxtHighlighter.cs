﻿namespace Skybrud.SyntaxHighlighter {

    /// <summary>
    /// Interface desciring a syntaxt highlighter.
    /// </summary>
    public interface ISyntaxtHighlighter {

        /// <summary>
        /// Highlights the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source / code to be highlighted.</param>
        /// <param name="language">The language to be used.</param>
        /// <returns>The highlighted source.</returns>
        public string Highlight(string source, Language language);

    }

}