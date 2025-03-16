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

    /// <summary>
    /// A list of error messages. Empty if the operation was successful.
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Gets the exception that caused the failure, if any.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified success status, optional errors, and optional exception.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="errors">Optional list of error messages.</param>
    /// <param name="exception">Optional exception that caused the failure.</param>
    protected Result(bool isSuccess, IEnumerable<string>? errors = null, Exception? exception = null)
    {
        IsSuccess = isSuccess;
        Errors = errors?.ToList() ?? [];
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
    public static Result Success()
    {
        return new Result(true);
    }

    /// <summary>
    /// Creates a failed result with a single error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    public static Result Failure(string error)
    {
        return new Result(false, [error]);
    }

    /// <summary>
    /// Creates a failed result with multiple error messages.
    /// </summary>
    /// <param name="errors">The error messages.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }

    /// <summary>
    /// Combines multiple results into a single result. If any of the results are failures, the combined result will also be a failure.
    /// </summary>
    /// <param name="results">The list of results to combine.</param>
    /// <returns>A <see cref="Result"/> representing the outcome of all combined results.</returns>
    public static Result Combine(params Result[] results)
    {
        var errors = results.Where(r => r.IsFailure).SelectMany(r => r.Errors).ToList();
        return errors.Count != 0 ? Result.Failure(errors) : Result.Success();
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
    /// Executes an action if the result is a failure, providing the error messages.
    /// </summary>
    /// <param name="action">The action to execute if failed, with error messages.</param>
    /// <returns>The current <see cref="Result"/>.</returns>
    public Result OnFailure(Action<IReadOnlyCollection<string>> action)
    {
        if (IsFailure)
        {
            action(Errors);
        }

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
            return Failure(ex.Message);
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