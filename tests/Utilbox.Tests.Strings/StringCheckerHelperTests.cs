using Utilbox.Strings;

namespace Utilbox.Tests.Strings
{
    public class StringCheckerHelperTests
    {
        [Theory]
        [InlineData("test@example.com", true)]
        [InlineData("invalid-email", false)]
        public void IsValidEmail_ShouldValidateEmailCorrectly(string email, bool expected)
        {
            var result = StringCheckerHelper.IsValidEmail(email);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", true)]
        [InlineData("abc123", false)]
        [InlineData("", false)]
        public void IsAlphabetic_ShouldValidateAlphabeticStringCorrectly(string input, bool expected)
        {
            var result = StringCheckerHelper.IsAlphabetic(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12345", true)]
        [InlineData("123a45", false)]
        [InlineData("", false)]
        public void ContainsOnlyDigits_ShouldValidateDigitsCorrectly(string input, bool expected)
        {
            var result = StringCheckerHelper.ContainsOnlyDigits(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Aba", true)]
        [InlineData("abc", false)]
        [InlineData("", false)]
        public void IsPalindrome_ShouldValidatePalindromeCorrectly(string input, bool expected)
        {
            var result = StringCheckerHelper.IsPalindrome(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("http://example.com", true)]
        [InlineData("https://example.com", true)]
        [InlineData("ftp://example.com", false)]
        [InlineData("example.com", false)]
        public void IsValidUrl_ShouldValidateUrlCorrectly(string input, bool expected)
        {
            var result = StringCheckerHelper.IsValidUrl(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", new[] { "he", "hi" }, true)]
        [InlineData("hello", new[] { "hi", "ho" }, false)]
        public void StartsWithAny_ShouldValidatePrefixesCorrectly(string input, string[] prefixes, bool expected)
        {
            var result = StringCheckerHelper.StartsWithAny(input, prefixes);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", new[] { "lo", "ho" }, true)]
        [InlineData("hello", new[] { "hi", "ho" }, false)]
        public void EndsWithAny_ShouldValidateSuffixesCorrectly(string input, string[] suffixes, bool expected)
        {
            var result = StringCheckerHelper.EndsWithAny(input, suffixes);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123456789X", true)]
        [InlineData("1234567890", false)]
        [InlineData("123456789", false)]
        public void IsValidIsbn10_ShouldValidateIsbn10Correctly(string isbn, bool expected)
        {
            var result = StringCheckerHelper.IsValidIsbn(isbn);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("9781234567897", true)]
        [InlineData("9781234567890", false)]
        [InlineData("978123456789", false)]
        public void IsValidIsbn13_ShouldValidateIsbn13Correctly(string isbn, bool expected)
        {
            var result = StringCheckerHelper.IsValidIsbn(isbn);
            Assert.Equal(expected, result);
        }
    }
}
