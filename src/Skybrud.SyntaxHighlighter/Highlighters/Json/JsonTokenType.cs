namespace Skybrud.SyntaxHighlighter.Highlighters.Json {

    /// <summary>
    /// Enum class indicating the type of a <see cref="JsonToken"/>.
    /// </summary>
    public enum JsonTokenType {
        
        /// <summary>
        /// Indictates that the token is a single-line comment.
        /// </summary>
        Comment,
        
        /// <summary>
        /// Indictates that the token is a multi-line block comment.
        /// </summary>
        BlockComment,

        /// <summary>
        /// Indictates that the token is an open object character.
        /// </summary>
        ObjectOpen,
        
        /// <summary>
        /// Indictates that the token is an closing object character.
        /// </summary>
        ObjectClose,

        /// <summary>
        /// Indictates that the token is an open array character.
        /// </summary>
        ArrayOpen,
        
        /// <summary>
        /// Indictates that the token is an closing object character.
        /// </summary>
        ArrayClose,

        /// <summary>
        /// Indictates that the token is a constant value - eg. a boolean.
        /// </summary>
        Constant,

        /// <summary>
        /// Indictates that the token is a number.
        /// </summary>
        Number,
        
        /// <summary>
        /// Indictates that the token is a string.
        /// </summary>
        String,

        /// <summary>
        /// Indicates that the token is of an unknown type.
        /// </summary>
        Other

    }

}