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
    public bool IsSuccess { get; protected set; }

    /// <summary>
    /// Gets a boolean indicating whether the operation was a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// A list of error messages. Empty if the operation was successful.
    /// </summary>
    public IList<string>? Errors { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified success status and optional errors.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="errors">Optional list of error messages.</param>
    private Result(bool isSuccess, params string[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors.ToList();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with no errors.
    /// </summary>
    protected Result()
    {
        Errors = new List<string>();
    }

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
        return new Result(false, error);
    }

    /// <summary>
    /// Creates a failed result with multiple error messages.
    /// </summary>
    /// <param name="errors">The error messages.</param>
    /// <returns>A failed <see cref="Result"/>.</returns>
    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors.ToArray());
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
}