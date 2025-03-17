using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DateRangeUtilitiesTests
{
    [Fact]
    public void CurrentDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DateTimeUtilities.GetStartOfDay(now);
        var expectedEnd = DateTimeUtilities.GetEndOfDay(now);

        // Act
        var result = DateRangeUtilities.CurrentDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddDays(1);
        var expectedStart = DateTimeUtilities.GetStartOfDay(now);
        var expectedEnd = DateTimeUtilities.GetEndOfDay(now);

        // Act
        var result = DateRangeUtilities.NextDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddDays(-1);
        var expectedStart = DateTimeUtilities.GetStartOfDay(now);
        var expectedEnd = DateTimeUtilities.GetEndOfDay(now);

        // Act
        var result = DateRangeUtilities.PreviousDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentWeek_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DateTimeUtilities.GetStartOfWeek(now);
        var expectedEnd = DateTimeUtilities.GetEndOfWeek(now);

        // Act
        var result = DateRangeUtilities.CurrentWeek();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DateTimeUtilities.GetStartOfMonth(now);
        var expectedEnd = DateTimeUtilities.GetEndOfMonth(now);

        // Act
        var result = DateRangeUtilities.CurrentMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddMonths(1);
        var expectedStart = DateTimeUtilities.GetStartOfMonth(now);
        var expectedEnd = DateTimeUtilities.GetEndOfMonth(now);

        // Act
        var result = DateRangeUtilities.NextMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddMonths(-1);
        var expectedStart = DateTimeUtilities.GetStartOfMonth(now);
        var expectedEnd = DateTimeUtilities.GetEndOfMonth(now);

        // Act
        var result = DateRangeUtilities.PreviousMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DateTimeUtilities.GetStartOfYear(now);
        var expectedEnd = DateTimeUtilities.GetEndOfYear(now);

        // Act
        var result = DateRangeUtilities.CurrentYear();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddYears(1);
        var expectedStart = DateTimeUtilities.GetStartOfYear(now);
        var expectedEnd = DateTimeUtilities.GetEndOfYear(now);

        // Act
        var result = DateRangeUtilities.NextYear();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddYears(-1);
        var expectedStart = DateTimeUtilities.GetStartOfYear(now);
        var expectedEnd = DateTimeUtilities.GetEndOfYear(now);

        // Act
        var result = DateRangeUtilities.PreviousYear();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void MonthOfYear_ReturnsCorrectSpan()
    {
        // Arrange
        var year = 2023;
        var month = 5;
        var expectedStart = new DateTime(year, month, 1);
        var expectedEnd = DateTimeUtilities.GetEndOfMonth(expectedStart);

        // Act
        var result = DateRangeUtilities.MonthOfYear(year, month);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void Year_ReturnsCorrectSpan()
    {
        // Arrange
        var year = 2023;
        var expectedStart = new DateTime(year, 1, 1);
        var expectedEnd = DateTimeUtilities.GetEndOfYear(expectedStart);

        // Act
        var result = DateRangeUtilities.Year(year);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void Overlaps_ReturnsTrueForOverlappingSpans()
    {
        // Arrange
        var span1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DateRange(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));

        // Act
        var result = DateRangeUtilities.Overlaps(span1, span2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Overlaps_ReturnsFalseForNonOverlappingSpans()
    {
        // Arrange
        var span1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DateRange(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        // Act
        var result = DateRangeUtilities.Overlaps(span1, span2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetIntersection_ReturnsCorrectSpanForOverlappingSpans()
    {
        // Arrange
        var span1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DateRange(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));
        var expectedStart = new DateTime(2023, 1, 5);
        var expectedEnd = new DateTime(2023, 1, 10);

        // Act
        var result = DateRangeUtilities.GetIntersection(span1, span2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedStart, result.Value.Start);
        Assert.Equal(expectedEnd, result.Value.End);
    }

    [Fact]
    public void GetIntersection_ReturnsNullForNonOverlappingSpans()
    {
        // Arrange
        var span1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DateRange(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        // Act
        var result = DateRangeUtilities.GetIntersection(span1, span2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MergeSpans_ReturnsCorrectMergedSpan()
    {
        // Arrange
        var spans = new List<DateRange>
        {
            new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10)),
            new DateRange(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15)),
            new DateRange(new DateTime(2023, 1, 20), new DateTime(2023, 1, 25))
        };
        var expectedStart = new DateTime(2023, 1, 1);
        var expectedEnd = new DateTime(2023, 1, 25);

        // Act
        var result = DateRangeUtilities.MergeSpans(spans);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void SplitSpan_ReturnsCorrectIntervals()
    {
        // Arrange
        var span = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var intervalCount = 3;
        var expectedIntervals = new List<DateRange>
        {
            new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 4)),
            new DateRange(new DateTime(2023, 1, 4), new DateTime(2023, 1, 7)),
            new DateRange(new DateTime(2023, 1, 7), new DateTime(2023, 1, 10))
        };

        // Act
        var result = DateRangeUtilities.SplitSpan(span, intervalCount).ToList();

        // Assert
        Assert.Equal(expectedIntervals.Count, result.Count);
        for (var i = 0; i < expectedIntervals.Count; i++)
        {
            Assert.Equal(expectedIntervals[i].Start, result[i].Start);
            Assert.Equal(expectedIntervals[i].End, result[i].End);
        }
    }

    [Fact]
    public void GenerateDailySpans_ReturnsCorrectSpans()
    {
        // Arrange
        var startDate = new DateTime(2023, 1, 1);
        var count = 3;
        var expectedSpans = new List<DateRange>
        {
            new DateRange(DateTimeUtilities.GetStartOfDay(startDate), DateTimeUtilities.GetEndOfDay(startDate)),
            new DateRange(DateTimeUtilities.GetStartOfDay(startDate.AddDays(1)), DateTimeUtilities.GetEndOfDay(startDate.AddDays(1))),
            new DateRange(DateTimeUtilities.GetStartOfDay(startDate.AddDays(2)), DateTimeUtilities.GetEndOfDay(startDate.AddDays(2)))
        };

        // Act
        var result = DateRangeUtilities.GenerateDailySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (var i = 0; i < expectedSpans.Count; i++)
        {
            Assert.Equal(expectedSpans[i].Start, result[i].Start);
            Assert.Equal(expectedSpans[i].End, result[i].End);
        }
    }

    [Fact]
    public void GenerateWeeklySpans_ReturnsCorrectSpans()
    {
        // Arrange
        var startDate = new DateTime(2023, 1, 1);
        var count = 3;
        var expectedSpans = new List<DateRange>
        {
            new DateRange(DateTimeUtilities.GetStartOfWeek(startDate), DateTimeUtilities.GetEndOfWeek(startDate)),
            new DateRange(DateTimeUtilities.GetStartOfWeek(startDate.AddWeeks(1)), DateTimeUtilities.GetEndOfWeek(startDate.AddWeeks(1))),
            new DateRange(DateTimeUtilities.GetStartOfWeek(startDate.AddWeeks(2)), DateTimeUtilities.GetEndOfWeek(startDate.AddWeeks(2)))
        };

        // Act
        var result = DateRangeUtilities.GenerateWeeklySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (var i = 0; i < expectedSpans.Count; i++)
        {
            Assert.Equal(expectedSpans[i].Start, result[i].Start);
            Assert.Equal(expectedSpans[i].End, result[i].End);
        }
    }

    [Fact]
    public void GenerateMonthlySpans_ReturnsCorrectSpans()
    {
        // Arrange
        var startDate = new DateTime(2023, 1, 1);
        var count = 3;
        var expectedSpans = new List<DateRange>
        {
            new DateRange(DateTimeUtilities.GetStartOfMonth(startDate), DateTimeUtilities.GetEndOfMonth(startDate)),
            new DateRange(DateTimeUtilities.GetStartOfMonth(startDate.AddMonths(1)), DateTimeUtilities.GetEndOfMonth(startDate.AddMonths(1))),
            new DateRange(DateTimeUtilities.GetStartOfMonth(startDate.AddMonths(2)), DateTimeUtilities.GetEndOfMonth(startDate.AddMonths(2)))
        };

        // Act
        var result = DateRangeUtilities.GenerateMonthlySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (var i = 0; i < expectedSpans.Count; i++)
        {
            Assert.Equal(expectedSpans[i].Start, result[i].Start);
            Assert.Equal(expectedSpans[i].End, result[i].End);
        }
    }

    [Fact]
    public void GetDuration_ReturnsCorrectDuration()
    {
        // Arrange
        var span = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var expectedDuration = new TimeSpan(9, 0, 0, 0);

        // Act
        var result = DateRangeUtilities.GetDuration(span);

        // Assert
        Assert.Equal(expectedDuration, result);
    }

    [Fact]
    public void ExtendSpan_ExtendsEndCorrectly()
    {
        // Arrange
        var span = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extensionDuration = new TimeSpan(5, 0, 0, 0);
        var expectedEnd = new DateTime(2023, 1, 15);

        // Act
        var result = DateRangeUtilities.ExtendSpan(span, extensionDuration);

        // Assert
        Assert.Equal(span.Start, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void ExtendSpan_ExtendsStartCorrectly()
    {
        // Arrange
        var span = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extensionDuration = new TimeSpan(5, 0, 0, 0);
        var expectedStart = new DateTime(2022, 12, 27);

        // Act
        var result = DateRangeUtilities.ExtendSpan(span, extensionDuration, extendEnd: false);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(span.End, result.End);
    }
}
