using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DateRangeTests
{
    [Fact]
    public void Constructor_ValidDates_ShouldSetProperties()
    {
        // Arrange
        var start = new DateTime(2023, 1, 1);
        var end = new DateTime(2023, 12, 31);

        // Act
        var dateRange = new DateRange(start, end);

        // Assert
        Assert.Equal(start, dateRange.Start);
        Assert.Equal(end, dateRange.End);
    }

    [Fact]
    public void Constructor_StartDateAfterEndDate_ShouldThrowArgumentException()
    {
        // Arrange
        var start = new DateTime(2023, 12, 31);
        var end = new DateTime(2023, 1, 1);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new DateRange(start, end));
        Assert.Equal("Start date must be before the end date (Parameter 'start')", exception.Message);
    }

    [Fact]
    public void Constructor_SameStartAndEndDate_ShouldSetProperties()
    {
        // Arrange
        var date = new DateTime(2023, 1, 1);

        // Act
        var dateRange = new DateRange(date, date);

        // Assert
        Assert.Equal(date, dateRange.Start);
        Assert.Equal(date, dateRange.End);
    }

    [Fact]
    public void Constructor_MaxDateRange_ShouldSetProperties()
    {
        // Arrange
        var start = DateTime.MinValue;
        var end = DateTime.MaxValue;

        // Act
        var dateRange = new DateRange(start, end);

        // Assert
        Assert.Equal(start, dateRange.Start);
        Assert.Equal(end, dateRange.End);
    }
}
