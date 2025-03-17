using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DateRangeExtensionsTests
{
    [Fact]
    public void Overlaps_ShouldReturnTrue_WhenRangesOverlap()
    {
        var range1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var range2 = new DateRange(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));

        Assert.True(range1.Overlaps(range2));
    }

    [Fact]
    public void Overlaps_ShouldReturnFalse_WhenRangesDoNotOverlap()
    {
        var range1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var range2 = new DateRange(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        Assert.False(range1.Overlaps(range2));
    }

    [Fact]
    public void GetIntersection_ShouldReturnIntersection_WhenRangesOverlap()
    {
        var range1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var range2 = new DateRange(new DateTime(2023, 1, 5), new DateTime(2023, 1, 15));

        var intersection = range1.GetIntersection(range2);

        Assert.NotNull(intersection);
        Assert.Equal(new DateTime(2023, 1, 5), intersection.Value.Start);
        Assert.Equal(new DateTime(2023, 1, 10), intersection.Value.End);
    }

    [Fact]
    public void GetIntersection_ShouldReturnNull_WhenRangesDoNotOverlap()
    {
        var range1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var range2 = new DateRange(new DateTime(2023, 1, 11), new DateTime(2023, 1, 20));

        var intersection = range1.GetIntersection(range2);

        Assert.Null(intersection);
    }

    [Fact]
    public void GetDuration_ShouldReturnCorrectDuration()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));

        var duration = range.GetDuration();

        Assert.Equal(TimeSpan.FromDays(9), duration);
    }

    [Fact]
    public void GetDays_ShouldReturnCorrectNumberOfDays()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));

        var days = range.GetDays();

        Assert.Equal(9, days);
    }

    [Fact]
    public void GetWeeks_ShouldReturnCorrectNumberOfWeeks()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 22));

        var weeks = range.GetWeeks();

        Assert.Equal(3, weeks);
    }

    [Fact]
    public void GetMonths_ShouldReturnCorrectNumberOfMonths()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 3, 1));

        var months = range.GetMonths();

        Assert.Equal(2, months);
    }

    [Fact]
    public void GetYears_ShouldReturnCorrectNumberOfYears()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2025, 1, 1));

        var years = range.GetYears();

        Assert.Equal(2, years);
    }

    [Fact]
    public void GetExactDays_ShouldReturnCorrectNumberOfExactDays()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));

        var exactDays = range.GetExactDays();

        Assert.Equal(9.0, exactDays);
    }

    [Fact]
    public void EnumerateDays_ShouldReturnAllDaysInRange()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 3));

        var days = range.EnumerateDays();

        Assert.Collection(days,
            day => Assert.Equal(new DateTime(2023, 1, 1), day),
            day => Assert.Equal(new DateTime(2023, 1, 2), day),
            day => Assert.Equal(new DateTime(2023, 1, 3), day));
    }

    [Fact]
    public void EnumerateMonths_ShouldReturnAllMonthsInRange()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 3, 31));

        var months = range.EnumerateMonths();

        Assert.Collection(months,
            month =>
            {
                Assert.Equal(new DateTime(2023, 1, 1), month.Start);
                Assert.Equal(new DateTime(2023, 1, 31, 23, 59, 59, 999), month.End);
            },
            month =>
            {
                Assert.Equal(new DateTime(2023, 2, 1), month.Start);
                Assert.Equal(new DateTime(2023, 2, 28, 23, 59, 59, 999), month.End);
            },
            month =>
            {
                Assert.Equal(new DateTime(2023, 3, 1), month.Start);
                Assert.Equal(new DateTime(2023, 3, 31, 23, 59, 59, 999), month.End);
            });
    }

    [Fact]
    public void ExtendSpan_ShouldExtendEndDate_WhenExtendEndIsTrue()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extendedRange = range.ExtendSpan(TimeSpan.FromDays(5), true);

        Assert.Equal(new DateTime(2023, 1, 1), extendedRange.Start);
        Assert.Equal(new DateTime(2023, 1, 15), extendedRange.End);
    }

    [Fact]
    public void ExtendSpan_ShouldExtendStartDate_WhenExtendEndIsFalse()
    {
        var range = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var extendedRange = range.ExtendSpan(TimeSpan.FromDays(5), false);

        Assert.Equal(new DateTime(2022, 12, 27), extendedRange.Start);
        Assert.Equal(new DateTime(2023, 1, 10), extendedRange.End);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenEndDateIsBeforeStartDate()
    {
        Assert.Throws<ArgumentException>(() => new DateRange(new DateTime(2023, 1, 10), new DateTime(2023, 1, 1)));
    }

    [Fact]
    public void GetIntersection_ShouldReturnNull_WhenRangesAreAdjacent()
    {
        var range1 = new DateRange(new DateTime(2023, 1, 1), new DateTime(2023, 1, 10));
        var range2 = new DateRange(new DateTime(2023, 1, 10), new DateTime(2023, 1, 20));

        var intersection = range1.GetIntersection(range2);

        Assert.Null(intersection);
    }
}
