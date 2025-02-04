using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DatetimeHelperTests
{
    [Fact]
    public void AddWeeks_ShouldAddCorrectNumberOfWeeks()
    {
        var date = new DateTime(2023, 1, 1);
        var result = date.AddWeeks(2);
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void GetStartOfDay_ShouldReturnStartOfDay()
    {
        var date = new DateTime(2023, 1, 1, 15, 30, 45);
        var result = DatetimeHelper.GetStartOfDay(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfDay_ShouldReturnEndOfDay()
    {
        var date = new DateTime(2023, 1, 1, 15, 30, 45);
        var result = DatetimeHelper.GetEndOfDay(date);
        Assert.Equal(new DateTime(2023, 1, 1, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetStartOfWeek_ShouldReturnStartOfWeek()
    {
        var date = new DateTime(2023, 1, 4); // Wednesday
        var result = DatetimeHelper.GetStartOfWeek(date);
        Assert.Equal(new DateTime(2023, 1, 1), result); // Sunday
    }

    [Fact]
    public void GetEndOfWeek_ShouldReturnEndOfWeek()
    {
        var date = new DateTime(2023, 1, 4); // Wednesday
        var result = DatetimeHelper.GetEndOfWeek(date);
        Assert.Equal(new DateTime(2023, 1, 7, 23, 59, 59, 999).AddTicks(9999), result); // Saturday
    }

    [Fact]
    public void GetStartOfMonth_ShouldReturnStartOfMonth()
    {
        var date = new DateTime(2023, 1, 15);
        var result = DatetimeHelper.GetStartOfMonth(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfMonth_ShouldReturnEndOfMonth()
    {
        var date = new DateTime(2023, 1, 15);
        var result = DatetimeHelper.GetEndOfMonth(date);
        Assert.Equal(new DateTime(2023, 1, 31, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetStartOfYear_ShouldReturnStartOfYear()
    {
        var date = new DateTime(2023, 6, 15);
        var result = DatetimeHelper.GetStartOfYear(date);
        Assert.Equal(new DateTime(2023, 1, 1), result);
    }

    [Fact]
    public void GetEndOfYear_ShouldReturnEndOfYear()
    {
        var date = new DateTime(2023, 6, 15);
        var result = DatetimeHelper.GetEndOfYear(date);
        Assert.Equal(new DateTime(2023, 12, 31, 23, 59, 59, 999).AddTicks(9999), result);
    }

    [Fact]
    public void GetNextBusinessDay_ShouldReturnNextBusinessDay()
    {
        var date = new DateTime(2023, 1, 6); // Friday
        var result = DatetimeHelper.GetNextBusinessDay(date);
        Assert.Equal(new DateTime(2023, 1, 9), result); // Monday
    }

    [Fact]
    public void GetPreviousBusinessDay_ShouldReturnPreviousBusinessDay()
    {
        var date = new DateTime(2023, 1, 9); // Monday
        var result = DatetimeHelper.GetPreviousBusinessDay(date);
        Assert.Equal(new DateTime(2023, 1, 6), result); // Friday
    }

    [Fact]
    public void GetBusinessDaysBetween_ShouldReturnCorrectNumberOfBusinessDays()
    {
        var startDate = new DateTime(2023, 1, 1); // Sunday
        var endDate = new DateTime(2023, 1, 10); // Tuesday
        var result = DatetimeHelper.GetBusinessDaysBetween(startDate, endDate);
        Assert.Equal(7, result);
    }

    [Fact]
    public void IsHoliday_ShouldReturnTrueIfDateIsHoliday()
    {
        var date = new DateTime(2023, 12, 25);
        var holidays = new List<DateTime> { new DateTime(2023, 12, 25) };
        var result = DatetimeHelper.IsHoliday(date, holidays);
        Assert.True(result);
    }

    [Fact]
    public void IsHoliday_ShouldReturnFalseIfDateIsNotHoliday()
    {
        var date = new DateTime(2023, 12, 24);
        var holidays = new List<DateTime> { new DateTime(2023, 12, 25) };
        var result = DatetimeHelper.IsHoliday(date, holidays);
        Assert.False(result);
    }

    [Fact]
    public void GetNearestWorkday_ShouldReturnNearestWorkday()
    {
        var date = new DateTime(2023, 1, 7); // Saturday
        var result = DatetimeHelper.GetNearestWorkday(date);
        Assert.Equal(new DateTime(2023, 1, 6), result); // Friday
    }

    [Fact]
    public void GetAge_ShouldReturnCorrectAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var currentDate = new DateTime(2023, 1, 1); // Use a fixed current date for testing
        var result = DatetimeHelper.GetAge(birthDate, currentDate);
        Assert.Equal(23, result);
    }

    [Fact]
    public void GetExactAge_ShouldReturnCorrectExactAge()
    {
        var birthDate = new DateTime(2000, 1, 1);
        var result = DatetimeHelper.GetExactAge(birthDate);
        var expected = DateTime.Now - birthDate;
        Assert.Equal(expected.Days, result.Days);
    }

    [Fact]
    public void GetWorkdaysInPeriod_ShouldReturnCorrectNumberOfWorkdays()
    {
        var startDate = new DateTime(2023, 1, 1); // Sunday
        var endDate = new DateTime(2023, 1, 10); // Tuesday
        var result = DatetimeHelper.GetWorkdaysInPeriod(startDate, endDate);
        Assert.Equal(7, result);
    }

    [Fact]
    public void IsWeekend_ShouldReturnTrueIfDateIsWeekend()
    {
        var date = new DateTime(2023, 1, 7); // Saturday
        var result = DatetimeHelper.IsWeekend(date);
        Assert.True(result);
    }

    [Fact]
    public void IsWeekend_ShouldReturnFalseIfDateIsNotWeekend()
    {
        var date = new DateTime(2023, 1, 6); // Friday
        var result = DatetimeHelper.IsWeekend(date);
        Assert.False(result);
    }
}
