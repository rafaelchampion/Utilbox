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

/// <summary>
/// Represents a result with a value of type <typeparamref name="T"/>. Can be either successful or failed.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// Gets the value associated with the result if it is successful.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified success status, value, and optional errors.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation was successful.</param>
    /// <param name="value">The value returned on success.</param>
    /// <param name="errors">Optional list of error messages.</param>
    private Result(bool isSuccess, T value, params string[]? errors)
    {
        Value = value;
        IsSuccess = isSuccess;
        Errors = errors?.ToList();
    }

    /// <summary>
    /// Creates a successful result with the given value.
    /// </summary>
    /// <param name="data">The value to return on success.</param>
    /// <returns>A successful <see cref="Result{T}"/>.</returns>
    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data);
    }

    /// <summary>
    /// Creates a failed result with a single error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    public new static Result<T> Failure(string error)
    {
        return new Result<T>(false, default!, error);
    }

    /// <summary>
    /// Creates a failed result with multiple error messages.
    /// </summary>
    /// <param name="errors">The error messages.</param>
    /// <returns>A failed <see cref="Result{T}"/>.</returns>
    public new static Result<T> Failure(IEnumerable<string>? errors)
    {
        return new Result<T>(false, default!, errors?.ToArray());
    }

    /// <summary>
    /// Maps the current result into a new result of type <typeparamref name="TOut"/> based on the success status.
    /// </summary>
    /// <typeparam name="TOut">The type to map the result to.</typeparam>
    /// <param name="mapFunc">A function to map the value.</param>
    /// <returns>A <see cref="Result{TOut}"/> representing the mapped outcome.</returns>
    public Result<TOut> Map<TOut>(Func<T, TOut> mapFunc)
    {
        return IsSuccess ? Result<TOut>.Success(mapFunc(Value)) : Result<TOut>.Failure(Errors);
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
}