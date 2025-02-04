using System;
using System.Threading.Tasks;

namespace Utilbox.Result;

public static class ResultExtensions
{
    /// <summary>
    /// Chains multiple Result-returning operations together synchronously. Each operation depends on the successful
    /// value of the previous Result. Use this method when you have a sequence of synchronous operations that each
    /// could potentially fail and return their own Result type.
    /// </summary>
    /// <typeparam name="TIn">The type of the value contained in the input Result</typeparam>
    /// <typeparam name="TOut">The type of the value that will be contained in the output Result</typeparam>
    /// <param name="result">The Result object to chain from</param>
    /// <param name="func">A function that takes the successful value from the input Result 
    /// and returns a new Result</param>
    /// <returns>
    /// Either:
    /// - A successful Result with the value from func if both the input Result and func succeed
    /// - A failure Result containing the error from the first failure encountered
    /// </returns>
    /// <example>
    /// <code>
    /// // Example with validation chain:
    /// var orderResult = Order.Create(customerId, amount)
    ///     .ChainResult(order => order.ValidateInventory())
    ///     .ChainResult(order => order.ValidateCustomerLimit());
    /// </code>
    /// </example>
    public static Result<TOut> Chain<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Result<TOut>> func)
    {
        return result.IsFailure ? Result<TOut>.Failure(result.Errors) : func(result.Value);
    }

    /// <summary>
    /// Chains multiple Result-returning operations together, where each operation depends on the successful value of the previous Result.
    /// This method is particularly useful when you need to perform a sequence of operations where each step could potentially fail
    /// and returns its own Result type.
    /// </summary>
    /// <typeparam name="TIn">The type of the value contained in the input Result</typeparam>
    /// <typeparam name="TOut">The type of the value that will be contained in the output Result</typeparam>
    /// <param name="result">The Result object to chain from</param>
    /// <param name="func">An asynchronous function that takes the successful value from the input Result 
    /// and returns a new Result</param>
    /// <returns>
    /// A Task containing either:
    /// - A successful Result with the value from func if both the input Result and func succeed
    /// - A failure Result containing the error from the first failure encountered
    /// </returns>
    /// <example>
    /// <code>
    /// // Example with payment processing:
    /// var orderResult = await Order.Create(customerId, amount)
    ///     .ChainResultAsync(async order => await paymentProcessor.ProcessPayment(order))
    ///     .ChainResultAsync(async payment => await paymentValidator.ValidatePayment(payment));
    /// </code>
    /// </example>
    /// <remarks>
    /// If the input Result is a failure, the func parameter will not be executed, and the original
    /// failure Result will be propagated. This enables automatic short-circuiting of the operation
    /// chain when any step fails.
    /// </remarks>
    public static async Task<Result<TOut>> ChainAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<Result<TOut>>> func)
    {
        if (result.IsFailure)
            return Result<TOut>.Failure(result.Errors);

        return await func(result.Value);
    }
    
    /// <summary>
    /// Executes a synchronous transformation on the value of a successful Result.
    /// This method is used when the transformation itself cannot fail and returns a regular value
    /// rather than another Result. It's particularly useful for simple data transformations
    /// or mapping operations.
    /// </summary>
    /// <typeparam name="TIn">The type of the value contained in the input Result</typeparam>
    /// <typeparam name="TOut">The type that the successful value will be transformed into</typeparam>
    /// <param name="result">The Result object containing the value to transform</param>
    /// <param name="func">A function that transforms the successful value into a new type.
    /// This function is only executed if the input Result is successful.</param>
    /// <returns>
    /// Either:
    /// - A successful Result wrapping the transformed value if the input Result was successful
    /// - A failure Result containing the original errors if the input Result was a failure
    /// </returns>
    /// <example>
    /// <code>
    /// // Example with DTO mapping:
    /// var userDtoResult = userResult
    ///     .OnSuccess(user => mapper.MapToDto(user));
    /// 
    /// // Example with value transformation:
    /// var priceResult = productResult
    ///     .OnSuccess(product => product.CalculateDiscountedPrice());
    /// </code>
    /// </example>
    public static Result<TOut> OnSuccess<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> func)
    {
        if (result.IsFailure)
            return Result<TOut>.Failure(result.Errors);
            
        var value = func(result.Value);
        return Result<TOut>.Success(value);
    }

    /// <summary>
    /// Executes an asynchronous transformation on the value of a successful Result.
    /// This method is used when the transformation itself cannot fail
    /// and returns a regular value rather than another Result.
    /// </summary>
    /// <typeparam name="TIn">The type of the value contained in the input Result</typeparam>
    /// <typeparam name="TOut">The type that the successful value will be transformed into</typeparam>
    /// <param name="result">The Result object containing the value to transform</param>
    /// <param name="func">An asynchronous function that transforms the successful value into a new type.
    /// This function is only executed if the input Result is successful.</param>
    /// <returns>
    /// A Task containing either:
    /// - A successful Result wrapping the transformed value if the input Result was successful
    /// - A failure Result containing the original errors if the input Result was a failure
    /// </returns>
    /// <example>
    /// <code>
    /// // Example with DTO mapping:
    /// var userDtoResult = await userResult
    ///     .OnSuccessAsync(async user => await mapper.MapToDto(user));
    /// 
    /// // Example with simple transformation:
    /// var confirmationResult = await paymentResult
    ///     .OnSuccessAsync(async payment => await GenerateConfirmation(payment));
    /// </code>
    /// </example>
    /// <remarks>
    /// This method is particularly useful for simple transformations like mapping to DTOs,
    /// generating derived values, or calling external services that don't use the Result pattern.
    /// The transformation function should not throw exceptions - use ChainResultAsync instead
    /// if the operation might fail.
    /// </remarks>
    public static async Task<Result<TOut>> OnSuccessAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<TOut>> func)
    {
        if (result.IsFailure)
            return Result<TOut>.Failure(result.Errors);

        var value = await func(result.Value);
        return Result<TOut>.Success(value);
    }
}