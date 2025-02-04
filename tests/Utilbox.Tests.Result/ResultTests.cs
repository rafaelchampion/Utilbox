using Utilbox.Result;

namespace Utilbox.Tests.Result;

public class ResultTests
{
    [Fact]
    public void Success_ShouldReturnSuccessfulResult()
    {
        var result = Utilbox.Result.Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Failure_WithSingleError_ShouldReturnFailedResult()
    {
        var errorMessage = "Error occurred";
        var result = Utilbox.Result.Result.Failure(errorMessage);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors, errorMessage);
    }

    [Fact]
    public void Failure_WithMultipleErrors_ShouldReturnFailedResult()
    {
        var errors = new List<string> { "Error 1", "Error 2" };
        var result = Utilbox.Result.Result.Failure(errors);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(errors, result.Errors);
    }

    [Fact]
    public void Combine_WithAllSuccessfulResults_ShouldReturnSuccessfulResult()
    {
        var result1 = Utilbox.Result.Result.Success();
        var result2 = Utilbox.Result.Result.Success();

        var combinedResult = Utilbox.Result.Result.Combine(result1, result2);

        Assert.True(combinedResult.IsSuccess);
        Assert.False(combinedResult.IsFailure);
        Assert.Empty(combinedResult.Errors);
    }

    [Fact]
    public void Combine_WithFailedResults_ShouldReturnFailedResult()
    {
        var result1 = Utilbox.Result.Result.Failure("Error 1");
        var result2 = Utilbox.Result.Result.Failure("Error 2");

        var combinedResult = Utilbox.Result.Result.Combine(result1, result2);

        Assert.False(combinedResult.IsSuccess);
        Assert.True(combinedResult.IsFailure);
        Assert.Contains("Error 1", combinedResult.Errors);
        Assert.Contains("Error 2", combinedResult.Errors);
    }

    [Fact]
    public void OnSuccess_ShouldExecuteAction_WhenResultIsSuccessful()
    {
        var result = Utilbox.Result.Result.Success();
        var actionExecuted = false;

        result.OnSuccess(() => actionExecuted = true);

        Assert.True(actionExecuted);
    }

    [Fact]
    public void OnSuccess_ShouldNotExecuteAction_WhenResultIsFailed()
    {
        var result = Utilbox.Result.Result.Failure("Error");
        var actionExecuted = false;

        result.OnSuccess(() => actionExecuted = true);

        Assert.False(actionExecuted);
    }

    [Fact]
    public void OnFailure_ShouldExecuteAction_WhenResultIsFailed()
    {
        var result = Utilbox.Result.Result.Failure("Error");
        var actionExecuted = false;

        result.OnFailure(() => actionExecuted = true);

        Assert.True(actionExecuted);
    }

    [Fact]
    public void OnFailure_ShouldNotExecuteAction_WhenResultIsSuccessful()
    {
        var result = Utilbox.Result.Result.Success();
        var actionExecuted = false;

        result.OnFailure(() => actionExecuted = true);

        Assert.False(actionExecuted);
    }

    [Fact]
    public void Try_ShouldReturnSuccessfulResult_WhenActionSucceeds()
    {
        var result = Utilbox.Result.Result.Try(() => { });

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Try_ShouldReturnFailedResult_WhenActionThrowsException()
    {
        var exceptionMessage = "Exception occurred";
        var result = Utilbox.Result.Result.Try(() => throw new Exception(exceptionMessage));

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors, exceptionMessage);
    }
}
