using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utilbox.Enums;

namespace Utilbox.Tests.Enums;

public class EnumExtensionsTests
{
    private enum TestEnum
    {
        [Display(Name = "First Value")]
        [Description("Description for First Value")]
        FirstValue = 1,

        [Display(Name = "Second Value")]
        [Description("Description for Second Value")]
        SecondValue = 2,

        ThirdValue = 3
    }

    [Fact]
    public void GetDisplayName_ShouldReturnDisplayName_WhenDisplayAttributeIsPresent()
    {
        var result = TestEnum.FirstValue.GetDisplayName();
        Assert.Equal("First Value", result);
    }

    [Fact]
    public void GetDisplayName_ShouldReturnEnumName_WhenDisplayAttributeIsNotPresent()
    {
        var result = TestEnum.ThirdValue.GetDisplayName();
        Assert.Equal("ThirdValue", result);
    }

    [Fact]
    public void GetDescription_ShouldReturnDescription_WhenDescriptionAttributeIsPresent()
    {
        var result = TestEnum.FirstValue.GetDescription();
        Assert.Equal("Description for First Value", result);
    }

    [Fact]
    public void GetDescription_ShouldReturnEnumName_WhenDescriptionAttributeIsNotPresent()
    {
        var result = TestEnum.ThirdValue.GetDescription();
        Assert.Equal("ThirdValue", result);
    }

    [Fact]
    public void ToInt_ShouldReturnIntegerValueOfEnum()
    {
        var result = TestEnum.FirstValue.ToInt();
        Assert.Equal(1, result);
    }

    [Fact]
    public void HasFlag_ShouldReturnTrue_WhenFlagIsSet()
    {
        var result = (TestEnum.FirstValue | TestEnum.SecondValue).HasFlag(TestEnum.FirstValue);
        Assert.True(result);
    }

    [Fact]
    public void HasFlag_ShouldReturnFalse_WhenFlagIsNotSet()
    {
        var result = TestEnum.FirstValue.HasFlag(TestEnum.SecondValue);
        Assert.False(result);
    }
}