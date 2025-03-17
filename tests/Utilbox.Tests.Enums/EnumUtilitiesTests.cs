using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utilbox.Enums;

namespace Utilbox.Tests.Enums;

public class EnumUtilitiesTests
{
    private enum TestEnum
    {
        [Description("First Value")]
        [Display(Name = "First")]
        First = 1,
        [Description("Second Value")]
        [Display(Name = "Second")]
        Second = 2,
        [Description("Third Value")]
        [Display(Name = "Third")]
        Third = 3
    }

    [Flags]
    private enum TestFlagsEnum
    {
        None = 0,
        Flag1 = 1,
        Flag2 = 2,
        Flag3 = 4
    }

    [Fact]
    public void IsValidEnumValue_ValidValue_ReturnsTrue()
    {
        Assert.True(EnumUtilities.IsValidEnumValue<TestEnum>(1));
    }

    [Fact]
    public void IsValidEnumValue_InvalidValue_ReturnsFalse()
    {
        Assert.False(EnumUtilities.IsValidEnumValue<TestEnum>(99));
    }

    [Fact]
    public void GetEnumValuesWithDescriptions_ReturnsCorrectValues()
    {
        var expected = new List<KeyValuePair<int, string>>
    {
        new(1, "First Value"),
        new(2, "Second Value"),
        new(3, "Third Value")
    };

        var result = EnumUtilities.GetEnumValuesWithDescriptions<TestEnum>();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetEnumByDisplayName_ValidDisplayName_ReturnsCorrectEnum()
    {
        var result = EnumUtilities.GetEnumByDisplayName<TestEnum>("Third");
        Assert.Equal(TestEnum.Third, result);
    }

    [Fact]
    public void GetEnumByDisplayName_InvalidDisplayName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => EnumUtilities.GetEnumByDisplayName<TestEnum>("Invalid"));
    }

    [Fact]
    public void GetEnumByDescription_ValidDescription_ReturnsCorrectEnum()
    {
        var result = EnumUtilities.GetEnumByDescription<TestEnum>("First Value");
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void GetEnumByDescription_InvalidDescription_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => EnumUtilities.GetEnumByDescription<TestEnum>("Invalid"));
    }

    [Fact]
    public void GetDescriptionByDisplayName_ValidDisplayName_ReturnsCorrectDescription()
    {
        var result = EnumUtilities.GetDescriptionByDisplayName<TestEnum>("Third");
        Assert.Equal("Third Value", result);
    }

    [Fact]
    public void GetDescriptionByDisplayName_InvalidDisplayName_ReturnsEmptyString()
    {
        var result = EnumUtilities.GetDescriptionByDisplayName<TestEnum>("Invalid");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void GetAllValues_ReturnsAllEnumValues()
    {
        var expected = new[] { TestEnum.First, TestEnum.Second, TestEnum.Third };
        var result = EnumUtilities.GetAllValues<TestEnum>();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseEnum_ValidString_ReturnsCorrectEnum()
    {
        var result = EnumUtilities.ParseEnum<TestEnum>("First");
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void ParseEnum_InvalidString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => EnumUtilities.ParseEnum<TestEnum>("Invalid"));
    }

    [Fact]
    public void GetEnumDisplayNames_ReturnsCorrectDisplayNames()
    {
        var expected = new Dictionary<TestEnum, string>
    {
        { TestEnum.First, "First" },
        { TestEnum.Second, "Second" },
        { TestEnum.Third, "Third" }
    };

        var result = EnumUtilities.GetEnumDisplayNames<TestEnum>();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetEnumDescriptions_ReturnsCorrectDescriptions()
    {
        var expected = new Dictionary<TestEnum, string>
    {
        { TestEnum.First, "First Value" },
        { TestEnum.Second, "Second Value" },
        { TestEnum.Third, "Third Value" }
    };

        var result = EnumUtilities.GetEnumDescriptions<TestEnum>();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CombineFlags_ValidFlags_ReturnsCombinedFlag()
    {
        var result = EnumUtilities.CombineFlags(TestFlagsEnum.Flag1, TestFlagsEnum.Flag2);
        Assert.Equal(TestFlagsEnum.Flag1 | TestFlagsEnum.Flag2, result);
    }

    [Fact]
    public void CombineFlags_EnumWithoutFlagsAttribute_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => EnumUtilities.CombineFlags(TestEnum.First, TestEnum.Second));
    }

    [Fact]
    public void RemoveFlag_ValidFlag_RemovesFlag()
    {
        var result = TestFlagsEnum.Flag1 | TestFlagsEnum.Flag2;
        result = result.RemoveFlag(TestFlagsEnum.Flag1);
        Assert.Equal(TestFlagsEnum.Flag2, result);
    }

    [Fact]
    public void RemoveFlag_EnumWithoutFlagsAttribute_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => TestEnum.First.RemoveFlag(TestEnum.Second));
    }
}