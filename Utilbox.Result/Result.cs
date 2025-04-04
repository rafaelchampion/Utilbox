using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Result;

/// <summary>
/// Represents the outcome of an operation. Can be either successful or failed, containing errors if failed.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets a boolean indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a boolean indicating whether the operation was a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    // Stores the primary error for simpler cases or quick type checking
    private readonly Error _primaryError;

    // Keeps track of multiple errors if needed
    private readonly List<Error>? _errors;

    /// <summary>
    /// Gets the primary error associated with a failure. Returns Error.None if successful.
    /// </summary>
    public Error Error => IsFailure ? _primaryError : Error.None;

    /// <summary>
    /// Gets the specific type of the primary error. Returns Generic if successful.
    /// </summary>
    public ErrorType ErrorType => Error.Type;

    /// <summary>
    /// Gets a list of all errors. Returns an empty list if successful.
    /// </summary>
    public IReadOnlyList<Error> Errors
    {
        get
        {
            if (_errors != null)
                return _errors.AsReadOnly();

            return IsFailure ? [_primaryError] : new List<Error>();
        }
    }

    /// <summary>
    /// Gets the exception that caused the failure, if any.
    /// Preserved for compatibility and specific scenarios.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified success status, optional errors, and optional exception.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="primaryError">Optional primary error. Defaults to the first error in the list if provided.</param>
    /// <param name="allErrors">Optional list of all errors.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    protected Result(bool isSuccess, Error? primaryError = null, List<Error>? allErrors = null, Exception? exception = null)
    {
        switch (isSuccess)
        {
            case true when (primaryError != null || allErrors is { Count: > 0 }):
                throw new InvalidOperationException("Cannot create a successful result with errors.");
            case false when primaryError == null && (allErrors == null || allErrors.Count == 0):
                throw new InvalidOperationException("Cannot create a failed result without an error.");
        }

        IsSuccess = isSuccess;
        _primaryError = primaryError ?? (allErrors?.FirstOrDefault() ?? Error.None);
        _errors = allErrors;
        Exception = exception;
    }

    /// <summary>
    /// Allows implicit conversion to bool for convenience.
    /// </summary>
    public static implicit operator bool(Result result) => result.IsSuccess;

    /// <summary>
    /// Creates a successful result with no errors.
    /// </summary>
    /// <returns>A successful <see cref="Result"/>.</returns>
    public static Result Success() => new Result(true);

    /// <summary>
    /// Creates a failed result with a single error.
    /// </summary>
    /// <param name="error">The error object.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    public static Result Failure(Error error, Exception? exception = null)
    {
        if (error == Error.None)
            throw new ArgumentException("Cannot create failure with Error.None.", nameof(error));
        return new Result(false, error, null, exception);
    }

    /// <summary>
    /// Creates a failed result with multiple errors.
    /// </summary>
    /// <param name="errors">The list of error objects.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    public static Result Failure(List<Error> errors, Exception? exception = null)
    {
        if (errors == null || errors.Count == 0 || errors.Contains(Error.None))
            throw new ArgumentException("Must provide at least one valid error.", nameof(errors));
        return new Result(false, errors.First(), errors, exception);
    }

    /// <summary>
    /// Creates a generic failed result with a single error description.
    /// </summary>
    /// <param name="errorDescription">The error description.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    /// <remarks>
    /// This method is deprecated. Use <see cref="Failure(Error, Exception?)"/> instead.
    /// </remarks>
    [Obsolete]
    public static Result Failure(string errorDescription, Exception? exception = null)
    {
        return Failure(Error.Generic("General", errorDescription), exception);
    }

    /// <summary>
    /// Creates a generic failed result with multiple error descriptions.
    /// </summary>
    /// <param name="errorDescriptions">The list of error descriptions.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    /// <remarks>
    /// This method is deprecated. Use <see cref="Failure(List{Error}, Exception?)"/> instead.
    /// </remarks>
    [Obsolete]
    public static Result Failure(IEnumerable<string> errorDescriptions, Exception? exception = null)
    {
        var descriptions = errorDescriptions?.ToList();
        if (descriptions == null || descriptions.Count == 0)
            throw new ArgumentException("Must provide at least one error description.", nameof(errorDescriptions));

        var errors = descriptions.Select(desc => Error.Generic("General", desc)).ToList();
        return Failure(errors, exception);
    }

    // --- Helper Static Methods for specific error types ---

    /// <summary>
    /// Creates a "Not Found" error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with a "Not Found" error.</returns>
    public static Result NotFound(string code = "NotFound", string description = "Resource not found.") => Failure(Error.NotFound(code, description));

    /// <summary>
    /// Creates a validation error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with a validation error.</returns>
    public static Result Validation(string code = "Validation", string description = "Input validation failed.") => Failure(Error.Validation(code, description));

    /// <summary>
    /// Creates a validation error result with multiple validation errors.
    /// </summary>
    /// <param name="validationErrors">The list of validation errors.</param>
    /// <returns>A failed <see cref="Result"/> with multiple validation errors.</returns>
    public static Result Validation(List<Error> validationErrors) => Failure(validationErrors);

    /// <summary>
    /// Creates a conflict error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with a conflict error.</returns>
    public static Result Conflict(string code = "Conflict", string description = "A conflict occurred.") => Failure(Error.Conflict(code, description));

    /// <summary>
    /// Creates an authentication error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with an authentication error.</returns>
    public static Result Unauthorized(string code = "AuthN", string description = "Authentication required.") => Failure(Error.Authentication(code, description));

    /// <summary>
    /// Creates an authorization error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with an authorization error.</returns>
    public static Result Forbidden(string code = "AuthZ", string description = "Authorization failed.") => Failure(Error.Authorization(code, description));

    /// <summary>
    /// Creates an unexpected error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result"/> with an unexpected error.</returns>
    public static Result Unexpected(string code = "Unexpected", string description = "An unexpected error occurred.") => Failure(Error.Unexpected(code, description));

    /// <summary>
    /// Combines multiple results into a single result. If any of the results are failures, the combined result will also be a failure.
    /// </summary>
    /// <param name="results">The list of results to combine.</param>
    /// <returns>A <see cref="Result"/> representing the outcome of all combined results.</returns>
    public static Result Combine(params Result[] results)
    {
        var combinedErrors = results.Where(r => r.IsFailure).SelectMany(r => r.Errors).ToList();
        return combinedErrors.Count == 0 ? Success() : Failure(combinedErrors);
    }

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <param name="action">The action to execute if successful.</param>
    /// <returns>The current <see cref="Result"/>.</returns>
    public Result OnSuccess(Action action)
    {
        if (IsSuccess)
        {
            action();
        }

        return this;
    }

    /// <summary>
    /// Executes an action if the result is a failure.
    /// </summary>
    /// <param name="action">The action to execute if failed.</param>
    /// <returns>The current <see cref="Result"/>.</returns>
    public Result OnFailure(Action action)
    {
        if (IsFailure)
        {
            action();
        }

        return this;
    }

    /// <summary>
    /// Executes an action if the result is a failure, providing the error.
    /// </summary>
    /// <param name="action">The action to execute if failed, with the primary error.</param>
    /// <returns>The current <see cref="Result"/>.</returns>
    public Result OnFailure(Action<Error> action)
    {
        if (IsFailure) action(Error); // Pass the primary error
        return this;
    }

    /// <summary>
    /// Attempts to execute an action, returning a result based on success or failure.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <returns>A <see cref="Result"/> representing the outcome of the action.</returns>
    public static Result Try(Action action)
    {
        try
        {
            action();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(Error.Unexpected(ex.GetType().Name, ex.Message), ex);
        }
    }

    /// <summary>
    /// Attempts to execute an action, returning a result based on success or failure.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">A function to handle any exceptions.</param>
    /// <returns>A <see cref="Result"/> representing the outcome of the action.</returns>
    public static Result Try(Action action, Func<Exception, IEnumerable<string>> errorHandler)
    {
        try
        {
            action();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(errorHandler(ex));
        }
    }

    /// <summary>
    /// Attempts to execute an action, handling specific exception types.
    /// </summary>
    /// <typeparam name="TException">The type of exception to handle.</typeparam>
    /// <param name="action">The action to execute.</param>
    /// <param name="exceptionHandler">A function to handle the specific exception.</param>
    /// <returns>A <see cref="Result"/> representing the outcome of the action.</returns>
    public static Result Try<TException>(Action action, Func<TException, IEnumerable<string>> exceptionHandler)
        where TException : Exception
    {
        try
        {
            action();
            return Success();
        }
        catch (TException ex)
        {
            return Failure(exceptionHandler(ex));
        }
        catch (Exception ex)
        {
            return Failure(ex.Message);
        }
    }
}