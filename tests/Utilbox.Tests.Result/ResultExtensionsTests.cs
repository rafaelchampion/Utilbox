using Utilbox.Result;

namespace Utilbox.Tests.Result;

public class ResultExtensionsTests
{
    [Fact]
    public void Chain_SuccessfulResult_ReturnsTransformedResult()
    {
        var initialResult = Result<int>.Success(5);
        var chainedResult = initialResult.Chain(value => Result<string>.Success(value.ToString()));

        Assert.True(chainedResult.IsSuccess);
        Assert.Equal("5", chainedResult.Value);
    }

    [Fact]
    public void Chain_FailedResult_ReturnsOriginalFailure()
    {
        var error = Error.Validation("InitialError", "Initial error");
        var initialResult = Result<int>.Failure(error);
        var chainedResult = initialResult.Chain(value => Result<string>.Success(value.ToString()));

        Assert.True(chainedResult.IsFailure);
        Assert.Equal(error, chainedResult.Error);
        Assert.Equal(ErrorType.Validation, chainedResult.ErrorType);
    }

    [Fact]
    public async Task ChainAsync_SuccessfulResult_ReturnsTransformedResult()
    {
        var initialResult = Result<int>.Success(5);
        var chainedResult = await initialResult.ChainAsync(async value => await Task.FromResult(Result<string>.Success(value.ToString())));

        Assert.True(chainedResult.IsSuccess);
        Assert.Equal("5", chainedResult.Value);
    }

    [Fact]
    public async Task ChainAsync_FailedResult_ReturnsOriginalFailure()
    {
        var error = Error.Validation("InitialError", "Initial error");
        var initialResult = Result<int>.Failure(error);
        var chainedResult = await initialResult.ChainAsync(async value => await Task.FromResult(Result<string>.Success(value.ToString())));

        Assert.True(chainedResult.IsFailure);
        Assert.Equal(error, chainedResult.Error);
        Assert.Equal(ErrorType.Validation, chainedResult.ErrorType);
    }

    [Fact]
    public void OnSuccess_SuccessfulResult_ReturnsTransformedResult()
    {
        var initialResult = Result<int>.Success(5);
        var transformedResult = initialResult.OnSuccess(value => value.ToString());

        Assert.True(transformedResult.IsSuccess);
        Assert.Equal("5", transformedResult.Value);
    }

    [Fact]
    public void OnSuccess_FailedResult_ReturnsOriginalFailure()
    {
        var error = Error.Validation("InitialError", "Initial error");
        var initialResult = Result<int>.Failure(error);
        var transformedResult = initialResult.OnSuccess(value => value.ToString());

        Assert.True(transformedResult.IsFailure);
        Assert.Equal(error, transformedResult.Error);
        Assert.Equal(ErrorType.Validation, transformedResult.ErrorType);
    }

    [Fact]
    public async Task OnSuccessAsync_SuccessfulResult_ReturnsTransformedResult()
    {
        var initialResult = Result<int>.Success(5);
        var transformedResult = await initialResult.OnSuccessAsync(async value => await Task.FromResult(value.ToString()));

        Assert.True(transformedResult.IsSuccess);
        Assert.Equal("5", transformedResult.Value);
    }

    [Fact]
    public async Task OnSuccessAsync_FailedResult_ReturnsOriginalFailure()
    {
        var error = Error.Validation("InitialError", "Initial error");
        var initialResult = Result<int>.Failure(error);
        var transformedResult = await initialResult.OnSuccessAsync(async value => await Task.FromResult(value.ToString()));

        Assert.True(transformedResult.IsFailure);
        Assert.Equal(error, transformedResult.Error);
        Assert.Equal(ErrorType.Validation, transformedResult.ErrorType);
    }
}
