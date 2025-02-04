using Utilbox.Strings;

namespace Utilbox.Tests.Strings
{
    public class StringManipulationHelperTests
    {
        [Fact]
        public void TrimToLength_InputIsNullOrEmpty_ReturnsEmptyString()
        {
            Assert.Equal(string.Empty, StringManipulationHelper.TrimToLength(null, 10));
            Assert.Equal(string.Empty, StringManipulationHelper.TrimToLength(string.Empty, 10));
        }

        [Fact]
        public void TrimToLength_MaxLengthIsZeroOrLess_ReturnsEmptyString()
        {
            Assert.Equal(string.Empty, StringManipulationHelper.TrimToLength("test", 0));
            Assert.Equal(string.Empty, StringManipulationHelper.TrimToLength("test", -1));
        }

        [Fact]
        public void TrimToLength_InputExceedsMaxLength_ReturnsTrimmedStringWithEllipsis()
        {
            Assert.Equal("test...", StringManipulationHelper.TrimToLength("testing", 4));
        }

        [Fact]
        public void TrimToLength_InputDoesNotExceedMaxLength_ReturnsOriginalString()
        {
            Assert.Equal("test", StringManipulationHelper.TrimToLength("test", 4));
        }

        [Fact]
        public void SafeSubstring_InputIsNullOrEmpty_ReturnsEmptyString()
        {
            Assert.Equal(string.Empty, StringManipulationHelper.SafeSubstring(null, 0, 5));
            Assert.Equal(string.Empty, StringManipulationHelper.SafeSubstring(string.Empty, 0, 5));
        }

        [Fact]
        public void SafeSubstring_StartIndexOutOfRange_ReturnsEmptyString()
        {
            Assert.Equal(string.Empty, StringManipulationHelper.SafeSubstring("test", -1, 2));
            Assert.Equal(string.Empty, StringManipulationHelper.SafeSubstring("test", 5, 2));
        }

        [Fact]
        public void SafeSubstring_ValidRange_ReturnsSubstring()
        {
            Assert.Equal("es", StringManipulationHelper.SafeSubstring("test", 1, 2));
        }

        [Fact]
        public void RemoveWhiteSpaces_InputIsNullOrEmpty_ReturnsOriginalString()
        {
            Assert.Null(StringManipulationHelper.RemoveWhiteSpaces(null));
            Assert.Equal(string.Empty, StringManipulationHelper.RemoveWhiteSpaces(string.Empty));
        }

        [Fact]
        public void RemoveWhiteSpaces_InputHasWhiteSpaces_ReturnsStringWithoutWhiteSpaces()
        {
            Assert.Equal("teststring", StringManipulationHelper.RemoveWhiteSpaces("test string"));
            Assert.Equal("teststring", StringManipulationHelper.RemoveWhiteSpaces("test\tstring"));
            Assert.Equal("teststring", StringManipulationHelper.RemoveWhiteSpaces("test\nstring"));
        }

        [Fact]
        public void ReplaceMultiple_InputIsNullOrEmpty_ReturnsOriginalString()
        {
            Assert.Null(StringManipulationHelper.ReplaceMultiple(null, new Dictionary<string, string>()));
            Assert.Equal(string.Empty, StringManipulationHelper.ReplaceMultiple(string.Empty, new Dictionary<string, string>()));
        }

        [Fact]
        public void ReplaceMultiple_ReplacementsIsNull_ReturnsOriginalString()
        {
            Assert.Equal("test", StringManipulationHelper.ReplaceMultiple("test", null));
        }

        [Fact]
        public void ReplaceMultiple_ValidReplacements_ReturnsReplacedString()
        {
            var replacements = new Dictionary<string, string> { { "test", "exam" }, { "string", "text" } };
            Assert.Equal("exam text", StringManipulationHelper.ReplaceMultiple("test string", replacements));
        }

        [Fact]
        public void Reverse_InputIsNullOrEmpty_ReturnsOriginalString()
        {
            Assert.Null(StringManipulationHelper.Reverse(null));
            Assert.Equal(string.Empty, StringManipulationHelper.Reverse(string.Empty));
        }

        [Fact]
        public void Reverse_ValidInput_ReturnsReversedString()
        {
            Assert.Equal("tset", StringManipulationHelper.Reverse("test"));
        }
    }
}
