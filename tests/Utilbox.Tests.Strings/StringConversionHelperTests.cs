using Utilbox.Strings;

namespace Utilbox.Tests.Strings
{
    public class StringConversionHelperTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("hello world", "Hello World")]
        [InlineData("HELLO WORLD", "Hello World")]
        [InlineData("hElLo WoRlD", "Hello World")]
        public void ToTitleCase_ShouldConvertToTitleCase(string input, string expected)
        {
            var result = StringConversionHelper.ToTitleCase(input);
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
            var result = StringConversionHelper.ToCamelCase(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("helloWorld", "hello_world")]
        [InlineData("HelloWorld", "hello_world")]
        [InlineData("helloWorldTest", "hello_world_test")]
        public void ToSnakeCase_ShouldConvertToSnakeCase(string input, string expected)
        {
            var result = StringConversionHelper.ToSnakeCase(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("helloWorld", "hello-world")]
        [InlineData("HelloWorld", "hello-world")]
        [InlineData("helloWorldTest", "hello-world-test")]
        public void ToKebabCase_ShouldConvertToKebabCase(string input, string expected)
        {
            var result = StringConversionHelper.ToKebabCase(input);
            Assert.Equal(expected, result);
        }
    }
}
