using System.Net;
using Utilbox.Response;

namespace Utilbox.Tests.Response;

public class ApiResponseTests
{
    [Fact]
    public void ApiResponse_DefaultConstructor_SetsDefaultValues()
    {
        var response = new ApiResponse<string>();

        Assert.False(response.Success);
        Assert.Equal(default(HttpStatusCode), response.StatusCode);
        Assert.Null(response.Data);
        Assert.Null(response.ErrorMessage);
        Assert.Empty(response.ValidationErrors);
        Assert.Empty(response.Metadata);
        Assert.Equal(DateTime.UtcNow.Date, response.Timestamp.Date);
        Assert.Null(response.RequestId);
    }

    [Fact]
    public void CreateSuccess_SetsSuccessValues()
    {
        var data = "Test Data";
        var response = ApiResponse<string>.CreateSuccess(data);

        Assert.True(response.Success);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(data, response.Data);
        Assert.Null(response.ErrorMessage);
        Assert.Empty(response.ValidationErrors);
        Assert.Equal(DateTime.UtcNow.Date, response.Timestamp.Date);
        Assert.Null(response.RequestId);
    }

    [Fact]
    public void CreateError_SetsErrorValues()
    {
        var errorMessage = "Test Error";
        var response = ApiResponse<string>.CreateError(errorMessage);

        Assert.False(response.Success);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Null(response.Data);
        Assert.Equal(errorMessage, response.ErrorMessage);
        Assert.Empty(response.ValidationErrors);
        Assert.Equal(DateTime.UtcNow.Date, response.Timestamp.Date);
        Assert.Null(response.RequestId);
    }

    [Fact]
    public void CreateValidationError_SetsValidationErrorValues()
    {
        var validationErrors = new List<OperationValidationError>
            {
                new OperationValidationError("Field1", "Error1"),
                new OperationValidationError("Field2", "Error2")
            };
        var response = ApiResponse<string>.CreateValidationError(validationErrors);

        Assert.False(response.Success);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Null(response.Data);
        Assert.Equal("Validation failed", response.ErrorMessage);
        Assert.Equal(validationErrors, response.ValidationErrors);
        Assert.Equal(DateTime.UtcNow.Date, response.Timestamp.Date);
        Assert.Null(response.RequestId);
    }

    [Fact]
    public void AddMetadata_AddsMetadata()
    {
        var response = new ApiResponse<string>();
        response.AddMetadata("Key1", "Value1");

        Assert.Single(response.Metadata);
        Assert.Equal("Value1", response.Metadata["Key1"]);
    }

    [Fact]
    public void AddPaginationMetadata_AddsPaginationMetadata()
    {
        var response = new ApiResponse<string>();
        response.AddPaginationMetadata(100, 10, 1, 10);

        Assert.Single(response.Metadata);
        var pagination = response.Metadata["Pagination"] as PaginationMetadata;
        Assert.NotNull(pagination);
        Assert.Equal(100, pagination.TotalItems);
        Assert.Equal(10, pagination.PageSize);
        Assert.Equal(1, pagination.CurrentPage);
        Assert.Equal(10, pagination.TotalPages);
    }
}