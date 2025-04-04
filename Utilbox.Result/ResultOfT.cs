using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Result;

/// <summary>
/// Represents a result with a value of type <typeparamref name="T"/>. Can be either successful or failed.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public class Result<T> : Result
{
    private readonly T? _value;

    /// <summary>
    /// Gets the value if the result is successful.
    /// Throws InvalidOperationException if accessed on a failed result.
    /// </summary>
    public T Value => IsSuccess ? _value! : throw new InvalidOperationException("Cannot access Value on a failed Result.");

    private Result(T value) : base(true) // Success constructor
    {
        _value = value;
    }

    private Result(Error error, Exception? exception = null) : base(false, error, null, exception) { }
    private Result(List<Error> errors, Exception? exception = null) : base(false, errors.First(), errors, exception) { }


    /// <summary>
    /// Creates a successful result with the given value.
    /// </summary>
    /// <param name="value">The value to return on success.</param>
    /// <returns>A successful <see cref="Result{T}"/>.</returns>
    public static Result<T> Success(T value) => new Result<T>(value);

    /// <summary>
    /// Creates a failed result with a single error.
    /// </summary>
    /// <param name="error">The error object.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    public new static Result<T> Failure(Error error, Exception? exception = null)
    {
        if (error == Error.None)
            throw new ArgumentException("Cannot create failure with Error.None.", nameof(error));
        return new Result<T>(error, exception);
    }

    /// <summary>
    /// Creates a failed result with multiple errors.
    /// </summary>
    /// <param name="errors">The list of error objects.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    public new static Result<T> Failure(List<Error> errors, Exception? exception = null)
    {
        if (errors == null || errors.Count == 0 || errors.Contains(Error.None))
            throw new ArgumentException("Must provide at least one valid error.", nameof(errors));
        return new Result<T>(errors, exception);
    }

    /// <summary>
    /// Creates a generic failed result with a single error description.
    /// </summary>
    /// <param name="errorDescription">The error description.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    /// <remarks>
    /// This method is deprecated. Use <see cref="Failure(Error, Exception?)"/> instead.
    /// </remarks>
    [Obsolete]
    public new static Result<T> Failure(string errorDescription, Exception? exception = null)
    {
        return Failure(Error.Generic("General", errorDescription), exception);
    }

    /// <summary>
    /// Creates a generic failed result with multiple error descriptions.
    /// </summary>
    /// <param name="errorDescriptions">The list of error descriptions.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    /// <remarks>
    /// This method is deprecated. Use <see cref="Failure(List{Error}, Exception?)"/> instead.
    /// </remarks>
    [Obsolete]
    public new static Result<T> Failure(IEnumerable<string> errorDescriptions, Exception? exception = null)
    {
        var descriptions = errorDescriptions?.ToList();
        if (descriptions == null || descriptions.Count == 0)
            throw new ArgumentException("Must provide at least one error description.", nameof(errorDescriptions));

        var errors = descriptions.Select(desc => Error.Generic("General", desc)).ToList();
        return Failure(errors, exception);
    }

    /// <summary>
    /// Creates a "Not Found" error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with a "Not Found" error.</returns>
    public new static Result<T> NotFound(string code = "NotFound", string description = "Resource not found.") => Failure(Error.NotFound(code, description));

    /// <summary>
    /// Creates a validation error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with a validation error.</returns>
    public new static Result<T> Validation(string code = "Validation", string description = "Input validation failed.") => Failure(Error.Validation(code, description));

    /// <summary>
    /// Creates a validation error result with multiple validation errors.
    /// </summary>
    /// <param name="validationErrors">The list of validation errors.</param>
    /// <returns>A failed <see cref="Result{T}"/> with multiple validation errors.</returns>
    public new static Result<T> Validation(List<Error> validationErrors) => Failure(validationErrors);

    /// <summary>
    /// Creates a conflict error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with a conflict error.</returns>
    public new static Result<T> Conflict(string code = "Conflict", string description = "A conflict occurred.") => Failure(Error.Conflict(code, description));

    /// <summary>
    /// Creates an authentication error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with an authentication error.</returns>
    public new static Result<T> Unauthorized(string code = "AuthN", string description = "Authentication required.") => Failure(Error.Authentication(code, description));

    /// <summary>
    /// Creates an authorization error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with an authorization error.</returns>
    public new static Result<T> Forbidden(string code = "AuthZ", string description = "Authorization failed.") => Failure(Error.Authorization(code, description));

    /// <summary>
    /// Creates an unexpected error result.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A failed <see cref="Result{T}"/> with an unexpected error.</returns>
    public new static Result<T> Unexpected(string code = "Unexpected", string description = "An unexpected error occurred.") => Failure(Error.Unexpected(code, description));

    /// <summary>
    /// Maps the current result into a new result of type <typeparamref name="TOut"/> based on the success status.
    /// </summary>
    /// <typeparam name="TOut">The type to map the result to.</typeparam>
    /// <param name="mapFunc">A function to map the value.</param>
    /// <returns>A <see cref="Result{TOut}"/> representing the mapped outcome.</returns>
    public Result<TOut> Map<TOut>(Func<T, TOut> mapFunc)
    {
        // Preserve errors on failure when mapping
        return IsSuccess ? Result<TOut>.Success(mapFunc(Value)) : Result<TOut>.Failure(Errors.ToList());
    }

    /// <summary>
    /// Pattern matching style handling of a Result.
    /// </summary>
    /// <typeparam name="TOut">The type of the output.</typeparam>
    /// <param name="onSuccess">Function to execute if the result is successful.</param>
    /// <param name="onFailure">Function to execute if the result is a failure.</param>
    /// <returns>The result of either the onSuccess or onFailure function.</returns>
    public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<IReadOnlyList<Error>, TOut> onFailure)
    {
        return IsSuccess ? onSuccess(Value) : onFailure(Errors);
    }

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <param name="action">The action to execute if successful.</param>
    /// <returns>The current <see cref="Result{T}"/>.</returns>
    public new Result<T> OnSuccess(Action action)
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
    /// <returns>The current <see cref="Result{T}"/>.</returns>
    public new Result<T> OnFailure(Action action)
    {
        if (IsFailure)
        {
            action();
        }

        return this;
    }

    /// <summary>
    /// Executes an action if the result is a failure, providing the error messages.
    /// </summary>
    /// <param name="action">The action to execute if failed, with error messages.</param>
    /// <returns>The current <see cref="Result{T}"/>.</returns>
    public new Result<T> OnFailure(Action<IReadOnlyCollection<Error>> action)
    {
        if (IsFailure)
        {
            action(Errors);
        }

        return this;
    }

    /// <summary>
    /// Ensures that a predicate is satisfied, otherwise returns a failure.
    /// </summary>
    /// <param name="predicate">The predicate to check.</param>
    /// <param name="error">The error to return if the predicate fails.</param>
    /// <returns>The current Result if the predicate is satisfied, otherwise a failure Result.</returns>
    public Result<T> Ensure(Func<T, bool> predicate, Error error)
    {
        if (IsFailure) return this;
        return predicate(Value) ? this : Failure(error);
    }

    /// <summary>
    /// Ensures that a predicate is satisfied, otherwise returns a failure.
    /// </summary>
    /// <param name="predicate">The predicate to check.</param>
    /// <param name="errorFactory">A function that creates an error based on the value if the predicate fails.</param>
    /// <returns>The current Result if the predicate is satisfied, otherwise a failure Result.</returns>
    public Result<T> Ensure(Func<T, bool> predicate, Func<T, Error> errorFactory) // Allow error generation based on value
    {
        if (IsFailure) return this;
        return predicate(Value) ? this : Failure(errorFactory(Value));
    }

    /// <summary>
    /// Attempts to execute a function and returns a Result.
    /// </summary>
    /// <param name="func">The function to execute.</param>
    /// <returns>A Result representing the outcome of the function.</returns>
    public static Result<T> Try(Func<T> func)
    {
        try
        {
            return Success(func());
        }
        catch (Exception ex)
        {
            return Failure(Error.Unexpected(ex.GetType().Name, ex.Message), ex);
        }
    }

    /// <summary>
    /// Attempts to execute a function and returns a Result.
    /// </summary>
    /// <param name="func">The function to execute.</param>
    /// <param name="errorHandler">A function to handle any exceptions.</param>
    /// <returns>A Result representing the outcome of the function.</returns>
    public static Result<T> Try(Func<T> func, Func<Exception, IEnumerable<string>> errorHandler)
    {
        try
        {
            var value = func();
            return Success(value);
        }
        catch (Exception ex)
        {
            return Failure(errorHandler(ex));
        }
    }

    /// <summary>
    /// Attempts to execute a function, handling specific exception types.
    /// </summary>
    /// <typeparam name="TException">The type of exception to handle.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="exceptionHandler">A function to handle the specific exception.</param>
    /// <returns>A Result representing the outcome of the function.</returns>
    public static Result<T> Try<TException>(Func<T> func, Func<TException, IEnumerable<string>> exceptionHandler)
        where TException : Exception
    {
        try
        {
            var value = func();
            return Success(value);
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