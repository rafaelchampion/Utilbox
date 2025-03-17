using Utilbox.Dates;

namespace Utilbox.Tests.Dates;

public class DateTimeExtensionsTests
{
    [Fact]
    public void AddWeeks_ShouldAddCorrectNumberOfWeeks()
    {
        var date = new DateTime(2023, 1, 1);
        var result = date.AddWeeks(2);
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }
}
