namespace Utilbox.Response;

/// <summary>
/// Represents a validation error for a specific field.
/// </summary>
public class OperationValidationError
{
    /// <summary>
    /// Gets or sets the name of the field that has the validation error.
    /// </summary>
    public string Field { get; set; }

    /// <summary>
    /// Gets or sets the error message for the validation error.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the error code for the validation error.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationValidationError"/> class.
    /// </summary>
    public OperationValidationError() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationValidationError"/> class with specified values.
    /// </summary>
    /// <param name="field">The name of the field with the validation error.</param>
    /// <param name="message">The error message.</param>
    /// <param name="code">Optional error code for the validation error.</param>
    public OperationValidationError(string field, string message, string code = null)
    {
        Field = field;
        Message = message;
        Code = code;
    }
}