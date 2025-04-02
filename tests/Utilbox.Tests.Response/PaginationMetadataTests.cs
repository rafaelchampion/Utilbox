using Utilbox.Response;

namespace Utilbox.Tests.Response;

public class PaginationMetadataTests
{
    [Fact]
    public void TotalItems_Should_SetAndGet()
    {
        var metadata = new PaginationMetadata();
        metadata.TotalItems = 100;
        Assert.Equal(100, metadata.TotalItems);
    }

    [Fact]
    public void PageSize_Should_SetAndGet()
    {
        var metadata = new PaginationMetadata();
        metadata.PageSize = 10;
        Assert.Equal(10, metadata.PageSize);
    }

    [Fact]
    public void CurrentPage_Should_SetAndGet()
    {
        var metadata = new PaginationMetadata();
        metadata.CurrentPage = 2;
        Assert.Equal(2, metadata.CurrentPage);
    }

    [Fact]
    public void TotalPages_Should_SetAndGet()
    {
        var metadata = new PaginationMetadata();
        metadata.TotalPages = 5;
        Assert.Equal(5, metadata.TotalPages);
    }

    [Fact]
    public void HasPrevious_Should_ReturnTrue_When_CurrentPageGreaterThanOne()
    {
        var metadata = new PaginationMetadata { CurrentPage = 2 };
        Assert.True(metadata.HasPrevious);
    }

    [Fact]
    public void HasPrevious_Should_ReturnFalse_When_CurrentPageIsOne()
    {
        var metadata = new PaginationMetadata { CurrentPage = 1 };
        Assert.False(metadata.HasPrevious);
    }

    [Fact]
    public void HasNext_Should_ReturnTrue_When_CurrentPageLessThanTotalPages()
    {
        var metadata = new PaginationMetadata { CurrentPage = 2, TotalPages = 5 };
        Assert.True(metadata.HasNext);
    }

    [Fact]
    public void HasNext_Should_ReturnFalse_When_CurrentPageEqualsTotalPages()
    {
        var metadata = new PaginationMetadata { CurrentPage = 5, TotalPages = 5 };
        Assert.False(metadata.HasNext);
    }
}
