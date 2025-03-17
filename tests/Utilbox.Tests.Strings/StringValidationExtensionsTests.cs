using Utilbox.Strings;

namespace Utilbox.Tests.Strings;

public class StringValidationExtensionsTests
{
    [Theory]
    [InlineData("test@example.com", true)]
    [InlineData("invalid-email", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsValidEmail_ShouldValidateEmailCorrectly(string email, bool expected)
    {
        var result = email.IsValidEmail();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", true)]
    [InlineData("abc123", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsAlphabetic_ShouldValidateAlphabeticCorrectly(string input, bool expected)
    {
        var result = input.IsAlphabetic();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("123.45", true)]
    [InlineData("abc", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsNumeric_ShouldValidateNumericCorrectly(string input, bool expected)
    {
        var result = input.IsNumeric();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("123a", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void ContainsOnlyDigits_ShouldValidateDigitsCorrectly(string input, bool expected)
    {
        var result = input.ContainsOnlyDigits();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("madam", true)]
    [InlineData("racecar", true)]
    [InlineData("hello", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsPalindrome_ShouldValidatePalindromeCorrectly(string input, bool expected)
    {
        var result = input.IsPalindrome();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("http://example.com", true)]
    [InlineData("https://example.com", true)]
    [InlineData("ftp://example.com", false)]
    [InlineData("invalid-url", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsValidUrl_ShouldValidateUrlCorrectly(string input, bool expected)
    {
        var result = input.IsValidUrl();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", new[] { "he", "hi" }, true)]
    [InlineData("hello", new[] { "hi", "ho" }, false)]
    [InlineData("hello", null, false)]
    [InlineData(null, new[] { "he" }, false)]
    public void StartsWithAny_ShouldValidatePrefixesCorrectly(string input, string[] prefixes, bool expected)
    {
        var result = input?.StartsWithAny(prefixes) ?? false;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", new[] { "lo", "hi" }, true)]
    [InlineData("hello", new[] { "hi", "ho" }, false)]
    [InlineData("hello", null, false)]
    [InlineData(null, new[] { "lo" }, false)]
    public void EndsWithAny_ShouldValidateSuffixesCorrectly(string input, string[] suffixes, bool expected)
    {
        var result = input?.EndsWithAny(suffixes) ?? false;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123456789X", true)]
    [InlineData("1234567890", false)]
    [InlineData("978-3-16-148410-0", true)]
    [InlineData("1234567890123", false)]
    [InlineData("1234567890128", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsValidIsbn_ShouldValidateIsbnCorrectly(string isbn, bool expected)
    {
        var result = isbn?.IsValidIsbn() ?? false;
        Assert.Equal(expected, result);
    }
}