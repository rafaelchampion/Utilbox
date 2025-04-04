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
        Assert.Equal(ErrorType.Generic, result.ErrorType);
    }

    [Fact]
    public void Failure_WithSingleError_ShouldReturnFailedResult()
    {
        var error = Error.Validation("InvalidInput", "The input was invalid");
        var result = Utilbox.Result.Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors, error);
        Assert.Equal(error, result.Error);
        Assert.Equal(ErrorType.Validation, result.ErrorType);
    }

    [Fact]
    public void Failure_WithMultipleErrors_ShouldReturnFailedResult()
    {
        var errors = new List<Error>
        {
            Error.Validation("InvalidInput", "The input was invalid"),
            Error.NotFound("UserNotFound", "User was not found")
        };
        var result = Utilbox.Result.Result.Failure(errors);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(errors, result.Errors);
        Assert.Equal(errors[0], result.Error); // First error should be primary
        Assert.Equal(ErrorType.Validation, result.ErrorType);
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
        var result1 = Utilbox.Result.Result.Failure(Error.Validation("Error1", "First error"));
        var result2 = Utilbox.Result.Result.Failure(Error.NotFound("Error2", "Second error"));

        var combinedResult = Utilbox.Result.Result.Combine(result1, result2);

        Assert.False(combinedResult.IsSuccess);
        Assert.True(combinedResult.IsFailure);
        Assert.Equal(2, combinedResult.Errors.Count);
        Assert.Contains(result1.Error, combinedResult.Errors);
        Assert.Contains(result2.Error, combinedResult.Errors);
    }

    [Fact]
    public void Combine_WithMixedResults_ShouldReturnFailedResult()
    {
        var result1 = Utilbox.Result.Result.Success();
        var result2 = Utilbox.Result.Result.Failure(Error.NotFound("Error2", "Second error"));

        var combinedResult = Utilbox.Result.Result.Combine(result1, result2);

        Assert.False(combinedResult.IsSuccess);
        Assert.True(combinedResult.IsFailure);
        Assert.Single(combinedResult.Errors, result2.Error);
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
        var result = Utilbox.Result.Result.Failure(Error.Generic("Error", "An error occurred"));
        var actionExecuted = false;

        result.OnSuccess(() => actionExecuted = true);

        Assert.False(actionExecuted);
    }

    [Fact]
    public void OnFailure_ShouldExecuteAction_WhenResultIsFailed()
    {
        var result = Utilbox.Result.Result.Failure(Error.Generic("Error", "An error occurred"));
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
    public void OnFailure_WithError_ShouldExecuteAction_WhenResultIsFailed()
    {
        var error = Error.Generic("Error", "An error occurred");
        var result = Utilbox.Result.Result.Failure(error);
        var receivedError = null as Error;

        result.OnFailure(e => receivedError = e);

        Assert.Equal(error, receivedError);
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
        Assert.Single(result.Errors);
        Assert.Equal(ErrorType.Unexpected, result.ErrorType);
        Assert.Equal(exceptionMessage, result.Error.Description);
    }

    [Fact]
    public void NotFound_ShouldReturnFailedResultWithNotFoundError()
    {
        var result = Utilbox.Result.Result.NotFound("UserNotFound", "User was not found");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
        Assert.Equal("UserNotFound", result.Error.Code);
        Assert.Equal("User was not found", result.Error.Description);
    }

    [Fact]
    public void Validation_ShouldReturnFailedResultWithValidationError()
    {
        var result = Utilbox.Result.Result.Validation("InvalidInput", "Input validation failed");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Validation, result.ErrorType);
        Assert.Equal("InvalidInput", result.Error.Code);
        Assert.Equal("Input validation failed", result.Error.Description);
    }

    [Fact]
    public void Validation_WithMultipleErrors_ShouldReturnFailedResultWithValidationErrors()
    {
        var errors = new List<Error>
        {
            Error.Validation("InvalidEmail", "Invalid email format"),
            Error.Validation("InvalidPassword", "Password too short")
        };
        var result = Utilbox.Result.Result.Validation(errors);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(2, result.Errors.Count);
        Assert.All(result.Errors, error => Assert.Equal(ErrorType.Validation, error.Type));
    }

    [Fact]
    public void Conflict_ShouldReturnFailedResultWithConflictError()
    {
        var result = Utilbox.Result.Result.Conflict("DuplicateEmail", "Email already exists");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Conflict, result.ErrorType);
        Assert.Equal("DuplicateEmail", result.Error.Code);
        Assert.Equal("Email already exists", result.Error.Description);
    }

    [Fact]
    public void Unauthorized_ShouldReturnFailedResultWithAuthenticationError()
    {
        var result = Utilbox.Result.Result.Unauthorized("InvalidToken", "Invalid authentication token");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Authentication, result.ErrorType);
        Assert.Equal("InvalidToken", result.Error.Code);
        Assert.Equal("Invalid authentication token", result.Error.Description);
    }

    [Fact]
    public void Forbidden_ShouldReturnFailedResultWithAuthorizationError()
    {
        var result = Utilbox.Result.Result.Forbidden("InsufficientPermissions", "User lacks required permissions");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Authorization, result.ErrorType);
        Assert.Equal("InsufficientPermissions", result.Error.Code);
        Assert.Equal("User lacks required permissions", result.Error.Description);
    }

    [Fact]
    public void Unexpected_ShouldReturnFailedResultWithUnexpectedError()
    {
        var result = Utilbox.Result.Result.Unexpected("DatabaseError", "Database connection failed");

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Unexpected, result.ErrorType);
        Assert.Equal("DatabaseError", result.Error.Code);
        Assert.Equal("Database connection failed", result.Error.Description);
    }

    [Fact]
    public void Try_WithErrorHandler_ShouldReturnFailedResultWithCustomError()
    {
        var result = Utilbox.Result.Result.Try(
            () => throw new Exception("Database error"),
            ex => new[] { $"DB_ERROR: {ex.Message}" }
        );

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
        Assert.Equal("DB_ERROR: Database error", result.Error.Description);
    }

    [Fact]
    public void Try_WithSpecificExceptionHandler_ShouldReturnFailedResultWithCustomError()
    {
        var result = Utilbox.Result.Result.Try<ArgumentException>(
            () => throw new ArgumentException("Invalid argument"),
            ex => new[] { $"ARG_ERROR: {ex.Message}" }
        );

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
        Assert.Equal("ARG_ERROR: Invalid argument", result.Error.Description);
    }
}
