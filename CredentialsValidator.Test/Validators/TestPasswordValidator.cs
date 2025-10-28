using CredentialsValidator.Validators;

namespace CredentialsValidator.Test.Validators;

public static class TestPasswordValidator
{
    public class NegativeTests
    {
        private readonly PasswordValidator _passwordValidator = new();

        [Fact]
        public void EmptyPasswordTest()
        {
            Assert.False(_passwordValidator.IsValid(""));
        }

        [Fact]
        public void WhitespacesOnlyTest()
        {
            Assert.False(_passwordValidator.IsValid("              "));
        }

        [Fact]
        public void LessThan6CharsTest()
        {
            Assert.False(_passwordValidator.IsValid("2B$"));
        }

        [Fact]
        public void Equals6CharsTest()
        {
            Assert.False(_passwordValidator.IsValid("a1C$ef"));
        }

        [Fact]
        public void MoreThan50CharsTest()
        {
            Assert.False(_passwordValidator.IsValid(new string('a', 51 - 5) + "$3Abc"));
        }

        [Fact]
        public void OnlyAlphabeticCharsTest()
        {
            Assert.False(_passwordValidator.IsValid(new string('a', 20)));
        }

        [Fact]
        public void OnlyNumsCharsTest()
        {
            Assert.False(_passwordValidator.IsValid(new string('2', 20)));
        }

        [Fact]
        public void OnlySpecSymbolsCharsTest()
        {
            Assert.False(_passwordValidator.IsValid(new string('$', 20)));
        }

        [Fact]
        public void NoNumsCharsTest()
        {
            Assert.False(_passwordValidator.IsValid("abcdefF$"));
        }

        [Fact]
        public void NoUpperAlphabeticCharsTest()
        {
            Assert.False(_passwordValidator.IsValid("abcdef2$"));
        }

        [Fact]
        public void NoSpecSymbolsCharsTest()
        {
            Assert.False(_passwordValidator.IsValid("abcdef2S"));
        }
    }

    public class PositiveTest
    {
        private readonly PasswordValidator _passwordValidator = new();

        [Fact]
        public void Equals50CharsTest()
        {
            Assert.True(_passwordValidator.IsValid(new string('a', 50 - 5) + "$3Abc"));
        }

        [Fact]
        public void Equals7CharsTest()
        {
            Assert.True(_passwordValidator.IsValid("%a214Bd"));
        }

        [Fact]
        public void NoLowercaseAlphabeticCharsTest()
        {
            Assert.True(_passwordValidator.IsValid("AHUGGDS^2"));
        }

        [Theory]
        [InlineData("abcd2F$")]
        [InlineData("2F$abcd")]
        [InlineData("$ab2cFd")]
        [InlineData("$ab2cFdasdfSHFiafsdifu964213")]
        public void ValidTest(string input)
        {
            Assert.True(_passwordValidator.IsValid(input));
        }
    }
}
