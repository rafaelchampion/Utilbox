using Utilbox.Strings;

namespace Utilbox.Tests.Strings;

public class StringCasingExtensionsTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("hello world", "Hello World")]
    [InlineData("HELLO WORLD", "Hello World")]
    [InlineData("hElLo WoRlD", "Hello World")]
    public void ToTitleCase_ShouldConvertToTitleCase(string input, string expected)
    {
        var result = input.ToTitleCase();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("helloWorld", "helloWorld")]
    [InlineData("HelloWorld", "helloWorld")]
    [InlineData("HELLO", "hELLO")]
    public void ToCamelCase_ShouldConvertToCamelCase(string input, string expected)
    {
        var result = input.ToCamelCase();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("helloWorld", "hello_world")]
    [InlineData("HelloWorld", "hello_world")]
    [InlineData("hello_world", "hello_world")]
    public void ToSnakeCase_ShouldConvertToSnakeCase(string input, string expected)
    {
        var result = input.ToSnakeCase();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("helloWorld", "hello-world")]
    [InlineData("HelloWorld", "hello-world")]
    [InlineData("hello-world", "hello-world")]
    public void ToKebabCase_ShouldConvertToKebabCase(string input, string expected)
    {
        var result = input.ToKebabCase();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("hello world", "HelloWorld")]
    [InlineData("HELLO WORLD", "HelloWorld")]
    [InlineData("hElLo WoRlD", "HelloWorld")]
    [InlineData("hello_world", "HelloWorld")]
    public void ToPascalCase_ShouldConvertToPascalCase(string input, string expected)
    {
        var result = input.ToPascalCase();
        Assert.Equal(expected, result);
    }
}