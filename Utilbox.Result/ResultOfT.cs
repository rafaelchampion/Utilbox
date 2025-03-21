﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilbox.Result;

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
    private Result(bool isSuccess, T value, IEnumerable<string>? errors = null)
        : base(isSuccess, errors)
    {
        Value = value;
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
        return new Result<T>(false, default, [error]);
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
    /// Pattern matching style handling of a Result.
    /// </summary>
    /// <typeparam name="TOut">The type of the output.</typeparam>
    /// <param name="onSuccess">Function to execute if the result is successful.</param>
    /// <param name="onFailure">Function to execute if the result is a failure.</param>
    /// <returns>The result of either the onSuccess or onFailure function.</returns>
    public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<IReadOnlyCollection<string>, TOut> onFailure)
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
    public new Result<T> OnFailure(Action<IReadOnlyCollection<string>> action)
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
    /// <param name="errorMessage">The error message to return if the predicate fails.</param>
    /// <returns>The current Result if the predicate is satisfied, otherwise a failure Result.</returns>
    public Result<T> Ensure(Func<T, bool> predicate, string errorMessage)
    {
        if (IsFailure)
            return this;

        return predicate(Value) ? this : Failure(errorMessage);
    }

    /// <summary>
    /// Ensures that a predicate is satisfied, otherwise returns a failure.
    /// </summary>
    /// <param name="predicate">The predicate to check.</param>
    /// <param name="errorMessages">The error messages to return if the predicate fails.</param>
    /// <returns>The current Result if the predicate is satisfied, otherwise a failure Result.</returns>
    public Result<T> Ensure(Func<T, bool> predicate, IEnumerable<string> errorMessages)
    {
        if (IsFailure)
            return this;

        return predicate(Value) ? this : Failure(errorMessages);
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
            var value = func();
            return Success(value);
        }
        catch (Exception ex)
        {
            return Failure(ex.Message);
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