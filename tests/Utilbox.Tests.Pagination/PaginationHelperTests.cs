using Utilbox.Pagination;

namespace Utilbox.Tests.Pagination;

public class PaginationHelperTests
{
    [Fact]
    public void Paginate_ShouldReturnCorrectPaginatedResult()
    {
        // Arrange
        var items = Enumerable.Range(1, 50).ToList();
        uint pageNumber = 2;
        uint pageSize = 10;

        // Act
        var result = PaginationHelper.Paginate(items, pageNumber, pageSize);

        // Assert
        Assert.Equal(pageNumber, result.PageNumber);
        Assert.Equal(pageSize, result.PageSize);
        Assert.Equal((uint)50, result.TotalItems);
        Assert.Equal((uint)5, result.TotalPages);
        Assert.Equal(10, result.Items.Count);
        Assert.Equal(11, result.Items.First());
        Assert.Equal(20, result.Items.Last());
    }

    [Fact]
    public void PaginateAsync_ShouldReturnCorrectPaginatedResult()
    {
        // Arrange
        var items = Enumerable.Range(1, 50).AsQueryable();
        uint pageNumber = 2;
        uint pageSize = 10;

        // Act
        var result = PaginationHelper.PaginateAsync(items, pageNumber, pageSize);

        // Assert
        Assert.Equal(pageNumber, result.PageNumber);
        Assert.Equal(pageSize, result.PageSize);
        Assert.Equal((uint)50, result.TotalItems);
        Assert.Equal((uint)5, result.TotalPages);
        Assert.Equal(10, result.Items.Count);
        Assert.Equal(11, result.Items.First());
        Assert.Equal(20, result.Items.Last());
    }
}
