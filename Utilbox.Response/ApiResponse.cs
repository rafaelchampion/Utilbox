using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace Utilbox.Response;

/// <summary>
/// A standardized response class for RESTful API endpoints that provides
/// consistent structure and behavior across different API implementations.
/// </summary>
/// <typeparam name="T">The type of data returned in the response.</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code of the response.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the data returned by the API operation.
    /// Will be default(T) if the operation was not successful.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the error message if the operation was not successful.
    /// Will be null if the operation was successful.
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the list of validation errors if applicable.
    /// Will be null or empty if there are no validation errors.
    /// </summary>
    public List<OperationValidationError> ValidationErrors { get; set; }

    /// <summary>
    /// Gets or sets additional metadata related to the response.
    /// </summary>
    public Dictionary<string, object> Metadata { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the response was generated.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the request ID for tracing and logging purposes.
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// Gets the numeric value of the HTTP status code.
    /// </summary>
    [JsonIgnore]
    public int StatusCodeValue => (int)StatusCode;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class with default values.
    /// </summary>
    public ApiResponse()
    {
        Timestamp = DateTime.UtcNow;
        ValidationErrors = new List<OperationValidationError>();
        Metadata = new Dictionary<string, object>();
    }

    /// <summary>
    /// Creates a successful response with the specified data.
    /// </summary>
    /// <param name="data">The data to include in the response.</param>
    /// <param name="statusCode">The HTTP status code (defaults to OK).</param>
    /// <param name="requestId">Optional request ID for tracing.</param>
    /// <returns>A successful API response containing the provided data.</returns>
    public static ApiResponse<T> CreateSuccess(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string requestId = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            StatusCode = statusCode,
            Data = data,
            RequestId = requestId
        };
    }

    /// <summary>
    /// Creates an error response with the specified error message.
    /// </summary>
    /// <param name="errorMessage">The error message describing what went wrong.</param>
    /// <param name="statusCode">The HTTP status code (defaults to BadRequest).</param>
    /// <param name="requestId">Optional request ID for tracing.</param>
    /// <returns>An error API response containing the provided error message.</returns>
    public static ApiResponse<T> CreateError(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string requestId = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            StatusCode = statusCode,
            ErrorMessage = errorMessage,
            RequestId = requestId
        };
    }

    /// <summary>
    /// Creates an error response with validation errors.
    /// </summary>
    /// <param name="validationErrors">The list of validation errors.</param>
    /// <param name="errorMessage">Optional general error message.</param>
    /// <param name="statusCode">The HTTP status code (defaults to BadRequest).</param>
    /// <param name="requestId">Optional request ID for tracing.</param>
    /// <returns>An error API response containing validation errors.</returns>
    public static ApiResponse<T> CreateValidationError(
        List<OperationValidationError> validationErrors,
        string errorMessage = "Validation failed",
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        string requestId = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            StatusCode = statusCode,
            ErrorMessage = errorMessage,
            ValidationErrors = validationErrors ?? new List<OperationValidationError>(),
            RequestId = requestId
        };
    }

    /// <summary>
    /// Add metadata to the response.
    /// </summary>
    /// <param name="key">The metadata key.</param>
    /// <param name="value">The metadata value.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ApiResponse<T> AddMetadata(string key, object value)
    {
        Metadata ??= new Dictionary<string, object>();
        Metadata[key] = value;
        return this;
    }

    /// <summary>
    /// Add pagination metadata to the response.
    /// </summary>
    /// <param name="totalItems">The total number of items.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="currentPage">The current page number.</param>
    /// <param name="totalPages">The total number of pages.</param>
    /// <returns>The current instance for method chaining.</returns>
    public ApiResponse<T> AddPaginationMetadata(int totalItems, int pageSize, int currentPage, int totalPages)
    {
        Metadata ??= new Dictionary<string, object>();
        Metadata["Pagination"] = new PaginationMetadata
        {
            TotalItems = totalItems,
            PageSize = pageSize,
            CurrentPage = currentPage,
            TotalPages = totalPages
        };
        return this;
    }
}