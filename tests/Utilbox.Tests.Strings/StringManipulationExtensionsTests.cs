using Utilbox.Strings;

namespace Utilbox.Tests.Strings;

public class StringManipulationExtensionsTests
{
    [Fact]
    public void TrimToLength_ShouldTrimAndAppendEllipsis_WhenStringExceedsMaxLength()
    {
        const string input = "This is a long string";
        const int maxLength = 10;
        const string expected = "This is a ...";

        var result = input.TrimToLength(maxLength);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TrimToLength_ShouldReturnOriginalString_WhenStringDoesNotExceedMaxLength()
    {
        const string input = "Short";
        const int maxLength = 10;

        var result = input.TrimToLength(maxLength);

        Assert.Equal(input, result);
    }

    [Fact]
    public void SafeSubstring_ShouldReturnSubstring_WhenStartAndLengthAreValid()
    {
        const string input = "Hello, World!";
        const int start = 7;
        const int length = 5;
        const string expected = "World";

        var result = input.SafeSubstring(start, length);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SafeSubstring_ShouldReturnEmptyString_WhenStartIsInvalid()
    {
        const string input = "Hello, World!";
        const int start = 20;
        const int length = 5;

        var result = input.SafeSubstring(start, length);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void RemoveWhiteSpaces_ShouldRemoveAllWhiteSpaces()
    {
        const string input = " H e l l o ";
        const string expected = "Hello";

        var result = input.RemoveWhiteSpaces();

        Assert.Equal(expected, result);
    }

    //[Fact]
    //public void RemoveAccents_ShouldRemoveAllDiacriticalMarks()
    //{
    //    const string input = "Café";
    //    const string expected = "Cafe";

    //    var result = input.RemoveAccents();

    //    Assert.Equal(expected.Normalize(NormalizationForm.FormC), result.Normalize(NormalizationForm.FormC));
    //}

    //[Fact]
    //public void Debug_StringEncoding()
    //{
    //    string cafe = "Café";
    //    Console.WriteLine("Original: " + cafe);

    //    byte[] bytes = Encoding.UTF8.GetBytes(cafe);
    //    Console.WriteLine("UTF-8 bytes: " + string.Join(", ", bytes));

    //    string decoded = Encoding.UTF8.GetString(bytes);
    //    Console.WriteLine("Decoded: " + decoded);

    //    // Try with explicit encoding
    //    byte[] utf8Bytes = Encoding.UTF8.GetBytes(cafe);
    //    Console.WriteLine("UTF-8 bytes: " + string.Join(", ", utf8Bytes));

    //    string utf8String = Encoding.UTF8.GetString(utf8Bytes);
    //    Console.WriteLine("UTF-8 string: " + utf8String);

    //    // Check what happens after normalization
    //    string normalized = cafe.Normalize(NormalizationForm.FormD);
    //    Console.WriteLine("Normalized (FormD): " + normalized);

    //    string removeAccents = cafe.RemoveAccents();
    //    Console.WriteLine("After RemoveAccents: " + removeAccents);

    //    Assert.True(true);
    //}

    [Fact]
    public void RemoveNonAlphanumeric_ShouldRemoveAllNonAlphanumericCharacters()
    {
        const string input = "Hello, World!";
        const string expected = "HelloWorld";

        var result = input.RemoveNonAlphanumeric();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReplaceMultiple_ShouldReplaceAllSpecifiedSubstrings()
    {
        const string input = "Hello, World!";
        var replacements = new Dictionary<string, string>
            {
                { "Hello", "Hi" },
                { "World", "Universe" }
            };
        const string expected = "Hi, Universe!";

        var result = input.ReplaceMultiple(replacements);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Reverse_ShouldReverseTheString()
    {
        const string input = "Hello";
        const string expected = "olleH";

        var result = input.Reverse();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseWords_ShouldReverseTheOrderOfWords()
    {
        const string input = "Hello World";
        const string expected = "World Hello";

        var result = input.ReverseWords();

        Assert.Equal(expected, result);
    }
}