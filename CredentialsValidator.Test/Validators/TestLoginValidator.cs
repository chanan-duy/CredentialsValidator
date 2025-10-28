using CredentialsValidator.Validators;

namespace CredentialsValidator.Test.Validators;

public static class TestLoginValidator
{
    public class NegativeTests
    {
        private readonly LoginValidator _loginValidator = new();

        [Fact]
        public void EmptyLoginTest()
        {
            Assert.False(_loginValidator.IsValid(""));
        }

        [Fact]
        public void WhitespacesOnlyTest()
        {
            Assert.False(_loginValidator.IsValid("              "));
        }

        [Fact]
        public void LessThan6CharsTest()
        {
            Assert.False(_loginValidator.IsValid("abc"));
        }

        [Fact]
        public void Equals6CharsTest()
        {
            Assert.False(_loginValidator.IsValid("abcdef"));
        }

        [Fact]
        public void MoreThan50CharsTest()
        {
            Assert.False(_loginValidator.IsValid(new string('a', 51)));
        }

        [Fact]
        public void UppercaseTest()
        {
            Assert.False(_loginValidator.IsValid(new string('B', 10)));
        }

        [Fact]
        public void NumberAtTheStartTest()
        {
            Assert.False(_loginValidator.IsValid("1abcdefgh"));
        }

        [Fact]
        public void DashAtTheStartTest()
        {
            Assert.False(_loginValidator.IsValid("-abcdefgh"));
        }

        [Fact]
        public void DashAtTheEndTest()
        {
            Assert.False(_loginValidator.IsValid("abcdefgh-"));
        }

        [Fact]
        public void OnlyNumbersTest()
        {
            Assert.False(_loginValidator.IsValid(new string('4', 10)));
        }

        [Fact]
        public void OnlyDashesTest()
        {
            Assert.False(_loginValidator.IsValid(new string('-', 10)));
        }
    }

    public class PositiveTests
    {
        private readonly LoginValidator _loginValidator = new();

        [Fact]
        public void Equals50CharsTest()
        {
            Assert.True(_loginValidator.IsValid(new string('a', 50)));
        }

        [Fact]
        public void NumberAtTheEndTest()
        {
            Assert.True(_loginValidator.IsValid("abcdefgh2"));
        }

        [Theory]
        [InlineData("abcdefg")]
        [InlineData("abcdefguirewfausdio")]
        public void ValidTest(string input)
        {
            Assert.True(_loginValidator.IsValid(input));
        }

        [Theory]
        [InlineData("abc-defg")]
        [InlineData("bdadef-g")]
        public void ValidWithDashTest(string input)
        {
            Assert.True(_loginValidator.IsValid(input));
        }

        [Theory]
        [InlineData("abc-defg1")]
        [InlineData("bdadef2-g")]
        public void ValidWithDashAndNumbersTest(string input)
        {
            Assert.True(_loginValidator.IsValid(input));
        }
    }
}
