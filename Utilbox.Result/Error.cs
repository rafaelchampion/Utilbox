namespace Utilbox.Result;

/// <summary>
/// Represents a detailed error, including a type, code, and description.
/// </summary>
public sealed class Error // Consider making this immutable (record or readonly properties)
{
    /// <summary>
    /// A unique code identifying the error (optional).
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// A description of the error.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The category of the error.
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Creates a new Error instance.
    /// </summary>
    /// <param name="code">Optional unique error code.</param>
    /// <param name="description">Error description.</param>
    /// <param name="type">Error category.</param>
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    // Static factory methods for common errors
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Generic);
    public static Error Validation(string code, string description) => new(code, description, ErrorType.Validation);
    public static Error NotFound(string code, string description) => new(code, description, ErrorType.NotFound);
    public static Error Conflict(string code, string description) => new(code, description, ErrorType.Conflict);
    public static Error Authentication(string code, string description) => new(code, description, ErrorType.Authentication);
    public static Error Authorization(string code, string description) => new(code, description, ErrorType.Authorization);
    public static Error Unexpected(string code, string description) => new(code, description, ErrorType.Unexpected);
    public static Error Generic(string code, string description) => new(code, description, ErrorType.Generic);
}