namespace Utilbox.Result;

/// <summary>
/// Defines standard categories for operation errors.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// A generic failure without a specific category.
    /// </summary>
    Generic = 0, // Default

    /// <summary>
    /// An error indicating input validation failed.
    /// Often maps to HTTP 400 Bad Request.
    /// </summary>
    Validation,

    /// <summary>
    /// An error indicating the requested resource was not found.
    /// Often maps to HTTP 404 Not Found.
    /// </summary>
    NotFound,

    /// <summary>
    /// An error indicating a conflict, e.g., resource already exists.
    /// Often maps to HTTP 409 Conflict.
    /// </summary>
    Conflict,

    /// <summary>
    /// An error indicating the user is not authenticated (not logged in).
    /// Often maps to HTTP 401 Unauthorized.
    /// </summary>
    Authentication,

    /// <summary>
    /// An error indicating the user is authenticated but not authorized for the action.
    /// Often maps to HTTP 403 Forbidden.
    /// </summary>
    Authorization,

    /// <summary>
    /// An error indicating an unexpected condition or internal server error.
    /// Often maps to HTTP 500 Internal Server Error.
    /// </summary>
    Unexpected
}