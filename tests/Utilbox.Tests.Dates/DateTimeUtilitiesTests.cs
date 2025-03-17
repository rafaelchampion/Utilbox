using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DateTimeUtilitiesTests
{
    [Fact]
    public void GetStartOfDay_ShouldReturnStartOfDay()
    {
        var date = new DateTime(2023, 1, 1, 15, 30, 45);
        var result = DateTimeUtilities.GetStartOfDay(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfDay_ShouldReturnEndOfDay()
    {
        var date = new DateTime(2023, 1, 1, 15, 30, 45);
        var result = DateTimeUtilities.GetEndOfDay(date);
        Assert.Equal(new DateTime(2023, 1, 1, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetStartOfWeek_ShouldReturnStartOfWeek()
    {
        var date = new DateTime(2023, 1, 4); // Wednesday
        var result = DateTimeUtilities.GetStartOfWeek(date);
        Assert.Equal(new DateTime(2023, 1, 1), result); // Sunday
    }

    [Fact]
    public void GetEndOfWeek_ShouldReturnEndOfWeek()
    {
        var date = new DateTime(2023, 1, 4); // Wednesday
        var result = DateTimeUtilities.GetEndOfWeek(date);
        Assert.Equal(new DateTime(2023, 1, 7, 23, 59, 59, 999).AddTicks(9999), result); // Saturday
    }

    [Fact]
    public void GetStartOfMonth_ShouldReturnStartOfMonth()
    {
        var date = new DateTime(2023, 1, 15);
        var result = DateTimeUtilities.GetStartOfMonth(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfMonth_ShouldReturnEndOfMonth()
    {
        var date = new DateTime(2023, 1, 15);
        var result = DateTimeUtilities.GetEndOfMonth(date);
        Assert.Equal(new DateTime(2023, 1, 31, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetStartOfYear_ShouldReturnStartOfYear()
    {
        var date = new DateTime(2023, 6, 15);
        var result = DateTimeUtilities.GetStartOfYear(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfYear_ShouldReturnEndOfYear()
    {
        var date = new DateTime(2023, 6, 15);
        var result = DateTimeUtilities.GetEndOfYear(date);
        Assert.Equal(new DateTime(2023, 12, 31, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetNextBusinessDay_ShouldReturnNextBusinessDay()
    {
        var date = new DateTime(2023, 1, 6); // Friday
        var result = DateTimeUtilities.GetNextBusinessDay(date);
        Assert.Equal(new DateTime(2023, 1, 9), result); // Monday
    }

    [Fact]
    public void GetPreviousBusinessDay_ShouldReturnPreviousBusinessDay()
    {
        var date = new DateTime(2023, 1, 9); // Monday
        var result = DateTimeUtilities.GetPreviousBusinessDay(date);
        Assert.Equal(new DateTime(2023, 1, 6), result); // Friday
    }

    [Fact]
    public void GetBusinessDaysBetween_ShouldReturnCorrectNumberOfBusinessDays()
    {
        var startDate = new DateTime(2023, 1, 1); // Sunday
        var endDate = new DateTime(2023, 1, 10); // Tuesday
        var result = DateTimeUtilities.GetBusinessDaysBetween(startDate, endDate);
        Assert.Equal(7, result);
    }

    [Fact]
    public void IsHoliday_ShouldReturnTrueIfDateIsHoliday()
    {
        var date = new DateTime(2023, 12, 25);
        var holidays = new List<DateTime> { new DateTime(2023, 12, 25) };
        var result = DateTimeUtilities.IsHoliday(date, holidays);
        Assert.True(result);
    }

    [Fact]
    public void IsHoliday_ShouldReturnFalseIfDateIsNotHoliday()
    {
        var date = new DateTime(2023, 12, 24);
        var holidays = new List<DateTime> { new DateTime(2023, 12, 25) };
        var result = DateTimeUtilities.IsHoliday(date, holidays);
        Assert.False(result);
    }

    [Fact]
    public void GetNearestWorkday_ShouldReturnNearestWorkday()
    {
        var date = new DateTime(2023, 1, 7); // Saturday
        var result = DateTimeUtilities.GetNearestWorkday(date);
        Assert.Equal(new DateTime(2023, 1, 6), result); // Friday
    }

    [Fact]
    public void GetAge_ShouldReturnCorrectAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var currentDate = new DateTime(2023, 1, 1); // Use a fixed current date for testing
        var result = DateTimeUtilities.GetAge(birthDate, currentDate);
        Assert.Equal(23, result);
    }

    [Fact]
    public void GetExactAge_ShouldReturnCorrectExactAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var result = DateTimeUtilities.GetExactAge(birthDate);
        var expected = DateTime.Now - birthDate;
        Assert.Equal(expected.Days, result.Days);
    }

    [Fact]
    public void GetWorkdaysInPeriod_ShouldReturnCorrectNumberOfWorkdays()
    {
        var startDate = new DateTime(2023, 1, 1); // Sunday
        var endDate = new DateTime(2023, 1, 10); // Tuesday
        var result = DateTimeUtilities.GetWorkdaysInPeriod(startDate, endDate);
        Assert.Equal(7, result);
    }

    [Fact]
    public void IsWeekend_ShouldReturnTrueIfDateIsWeekend()
    {
        var date = new DateTime(2023, 1, 7); // Saturday
        var result = DateTimeUtilities.IsWeekend(date);
        Assert.True(result);
    }

    [Fact]
    public void IsWeekend_ShouldReturnFalseIfDateIsNotWeekend()
    {
        var date = new DateTime(2023, 1, 6); // Friday
        var result = DateTimeUtilities.IsWeekend(date);
        Assert.False(result);
    }
}
