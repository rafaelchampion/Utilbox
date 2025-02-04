using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DatetimeSpanHelperTests
{
    [Fact]
    public void CurrentDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DatetimeHelper.GetStartOfDay(now);
        var expectedEnd = DatetimeHelper.GetEndOfDay(now);

        // Act
        var result = DatetimeSpanHelper.CurrentDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddDays(1);
        var expectedStart = DatetimeHelper.GetStartOfDay(now);
        var expectedEnd = DatetimeHelper.GetEndOfDay(now);

        // Act
        var result = DatetimeSpanHelper.NextDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousDay_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddDays(-1);
        var expectedStart = DatetimeHelper.GetStartOfDay(now);
        var expectedEnd = DatetimeHelper.GetEndOfDay(now);

        // Act
        var result = DatetimeSpanHelper.PreviousDay();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentWeek_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DatetimeHelper.GetStartOfWeek(now);
        var expectedEnd = DatetimeHelper.GetEndOfWeek(now);

        // Act
        var result = DatetimeSpanHelper.CurrentWeek();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DatetimeHelper.GetStartOfMonth(now);
        var expectedEnd = DatetimeHelper.GetEndOfMonth(now);

        // Act
        var result = DatetimeSpanHelper.CurrentMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddMonths(1);
        var expectedStart = DatetimeHelper.GetStartOfMonth(now);
        var expectedEnd = DatetimeHelper.GetEndOfMonth(now);

        // Act
        var result = DatetimeSpanHelper.NextMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousMonth_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddMonths(-1);
        var expectedStart = DatetimeHelper.GetStartOfMonth(now);
        var expectedEnd = DatetimeHelper.GetEndOfMonth(now);

        // Act
        var result = DatetimeSpanHelper.PreviousMonth();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void CurrentYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow;
        var expectedStart = DatetimeHelper.GetStartOfYear(now);
        var expectedEnd = DatetimeHelper.GetEndOfYear(now);

        // Act
        var result = DatetimeSpanHelper.CurrentYear();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void NextYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddYears(1);
        var expectedStart = DatetimeHelper.GetStartOfYear(now);
        var expectedEnd = DatetimeHelper.GetEndOfYear(now);

        // Act
        var result = DatetimeSpanHelper.NextYear();

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void PreviousYear_ReturnsCorrectSpan()
    {
        // Arrange
        var now = DateTime.UtcNow.AddYears(-1);
        var expectedStart = DatetimeHelper.GetStartOfYear(now);
        var expectedEnd = DatetimeHelper.GetEndOfYear(now);

        // Act
        var result = DatetimeSpanHelper.PreviousYear();

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
        var expectedEnd = DatetimeHelper.GetEndOfMonth(expectedStart);

        // Act
        var result = DatetimeSpanHelper.MonthOfYear(year, month);

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
        var expectedEnd = DatetimeHelper.GetEndOfYear(expectedStart);

        // Act
        var result = DatetimeSpanHelper.Year(year);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void Overlaps_ReturnsTrueForOverlappingSpans()
    {
        // Arrange
        var span1 = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DatetimeSpan(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));

        // Act
        var result = DatetimeSpanHelper.Overlaps(span1, span2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Overlaps_ReturnsFalseForNonOverlappingSpans()
    {
        // Arrange
        var span1 = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DatetimeSpan(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        // Act
        var result = DatetimeSpanHelper.Overlaps(span1, span2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetIntersection_ReturnsCorrectSpanForOverlappingSpans()
    {
        // Arrange
        var span1 = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DatetimeSpan(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));
        var expectedStart = new DateTime(2023, 1, 5);
        var expectedEnd = new DateTime(2023, 1, 10);

        // Act
        var result = DatetimeSpanHelper.GetIntersection(span1, span2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedStart, result.Value.Start);
        Assert.Equal(expectedEnd, result.Value.End);
    }

    [Fact]
    public void GetIntersection_ReturnsNullForNonOverlappingSpans()
    {
        // Arrange
        var span1 = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var span2 = new DatetimeSpan(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        // Act
        var result = DatetimeSpanHelper.GetIntersection(span1, span2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MergeSpans_ReturnsCorrectMergedSpan()
    {
        // Arrange
        var spans = new List<DatetimeSpan>
        {
            new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10)),
            new DatetimeSpan(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15)),
            new DatetimeSpan(new DateTime(2023, 1, 20), new DateTime(2023, 1, 25))
        };
        var expectedStart = new DateTime(2023, 1, 1);
        var expectedEnd = new DateTime(2023, 1, 25);

        // Act
        var result = DatetimeSpanHelper.MergeSpans(spans);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void SplitSpan_ReturnsCorrectIntervals()
    {
        // Arrange
        var span = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var intervalCount = 3;
        var expectedIntervals = new List<DatetimeSpan>
        {
            new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 4)),
            new DatetimeSpan(new DateTime(2023, 1, 4), new DateTime(2023, 1, 7)),
            new DatetimeSpan(new DateTime(2023, 1, 7), new DateTime(2023, 1, 10))
        };

        // Act
        var result = DatetimeSpanHelper.SplitSpan(span, intervalCount).ToList();

        // Assert
        Assert.Equal(expectedIntervals.Count, result.Count);
        for (int i = 0; i < expectedIntervals.Count; i++)
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
        var expectedSpans = new List<DatetimeSpan>
        {
            new DatetimeSpan(DatetimeHelper.GetStartOfDay(startDate), DatetimeHelper.GetEndOfDay(startDate)),
            new DatetimeSpan(DatetimeHelper.GetStartOfDay(startDate.AddDays(1)), DatetimeHelper.GetEndOfDay(startDate.AddDays(1))),
            new DatetimeSpan(DatetimeHelper.GetStartOfDay(startDate.AddDays(2)), DatetimeHelper.GetEndOfDay(startDate.AddDays(2)))
        };

        // Act
        var result = DatetimeSpanHelper.GenerateDailySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (int i = 0; i < expectedSpans.Count; i++)
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
        var expectedSpans = new List<DatetimeSpan>
        {
            new DatetimeSpan(DatetimeHelper.GetStartOfWeek(startDate), DatetimeHelper.GetEndOfWeek(startDate)),
            new DatetimeSpan(DatetimeHelper.GetStartOfWeek(startDate.AddWeeks(1)), DatetimeHelper.GetEndOfWeek(startDate.AddWeeks(1))),
            new DatetimeSpan(DatetimeHelper.GetStartOfWeek(startDate.AddWeeks(2)), DatetimeHelper.GetEndOfWeek(startDate.AddWeeks(2)))
        };

        // Act
        var result = DatetimeSpanHelper.GenerateWeeklySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (int i = 0; i < expectedSpans.Count; i++)
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
        var expectedSpans = new List<DatetimeSpan>
        {
            new DatetimeSpan(DatetimeHelper.GetStartOfMonth(startDate), DatetimeHelper.GetEndOfMonth(startDate)),
            new DatetimeSpan(DatetimeHelper.GetStartOfMonth(startDate.AddMonths(1)), DatetimeHelper.GetEndOfMonth(startDate.AddMonths(1))),
            new DatetimeSpan(DatetimeHelper.GetStartOfMonth(startDate.AddMonths(2)), DatetimeHelper.GetEndOfMonth(startDate.AddMonths(2)))
        };

        // Act
        var result = DatetimeSpanHelper.GenerateMonthlySpans(startDate, count).ToList();

        // Assert
        Assert.Equal(expectedSpans.Count, result.Count);
        for (int i = 0; i < expectedSpans.Count; i++)
        {
            Assert.Equal(expectedSpans[i].Start, result[i].Start);
            Assert.Equal(expectedSpans[i].End, result[i].End);
        }
    }

    [Fact]
    public void GetDuration_ReturnsCorrectDuration()
    {
        // Arrange
        var span = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var expectedDuration = new TimeSpan(9, 0, 0, 0);

        // Act
        var result = DatetimeSpanHelper.GetDuration(span);

        // Assert
        Assert.Equal(expectedDuration, result);
    }

    [Fact]
    public void ExtendSpan_ExtendsEndCorrectly()
    {
        // Arrange
        var span = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extensionDuration = new TimeSpan(5, 0, 0, 0);
        var expectedEnd = new DateTime(2023, 1, 15);

        // Act
        var result = DatetimeSpanHelper.ExtendSpan(span, extensionDuration);

        // Assert
        Assert.Equal(span.Start, result.Start);
        Assert.Equal(expectedEnd, result.End);
    }

    [Fact]
    public void ExtendSpan_ExtendsStartCorrectly()
    {
        // Arrange
        var span = new DatetimeSpan(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extensionDuration = new TimeSpan(5, 0, 0, 0);
        var expectedStart = new DateTime(2022, 12, 27);

        // Act
        var result = DatetimeSpanHelper.ExtendSpan(span, extensionDuration, extendEnd: false);

        // Assert
        Assert.Equal(expectedStart, result.Start);
        Assert.Equal(span.End, result.End);
    }
}
