using Utilbox.Pagination;

namespace Utilbox.Tests.Pagination;

public class PaginatedResultTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        uint pageNumber = 1;
        uint pageSize = 3;
        uint totalItems = 10;
        uint totalPages = 4;

        // Act
        var result = new PaginatedResult<int>(items, pageNumber, pageSize, totalItems, totalPages);

        // Assert
        Assert.Equal(items, result.Items);
        Assert.Equal(pageNumber, result.PageNumber);
        Assert.Equal(pageSize, result.PageSize);
        Assert.Equal(totalItems, result.TotalItems);
        Assert.Equal(totalPages, result.TotalPages);
    }

    [Fact]
    public void HasNextPage_ShouldReturnTrue_WhenThereIsNextPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        uint pageNumber = 1;
        uint pageSize = 3;
        uint totalItems = 10;
        uint totalPages = 4;

        // Act
        var result = new PaginatedResult<int>(items, pageNumber, pageSize, totalItems, totalPages);

        // Assert
        Assert.True(result.HasNextPage);
    }

    [Fact]
    public void HasNextPage_ShouldReturnFalse_WhenThereIsNoNextPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        uint pageNumber = 4;
        uint pageSize = 3;
        uint totalItems = 10;
        uint totalPages = 4;

        // Act
        var result = new PaginatedResult<int>(items, pageNumber, pageSize, totalItems, totalPages);

        // Assert
        Assert.False(result.HasNextPage);
    }

    [Fact]
    public void HasPreviousPage_ShouldReturnTrue_WhenThereIsPreviousPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        uint pageNumber = 2;
        uint pageSize = 3;
        uint totalItems = 10;
        uint totalPages = 4;

        // Act
        var result = new PaginatedResult<int>(items, pageNumber, pageSize, totalItems, totalPages);

        // Assert
        Assert.True(result.HasPreviousPage);
    }

    [Fact]
    public void HasPreviousPage_ShouldReturnFalse_WhenThereIsNoPreviousPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        uint pageNumber = 1;
        uint pageSize = 3;
        uint totalItems = 10;
        uint totalPages = 4;

        // Act
        var result = new PaginatedResult<int>(items, pageNumber, pageSize, totalItems, totalPages);

        // Assert
        Assert.False(result.HasPreviousPage);
    }
}
