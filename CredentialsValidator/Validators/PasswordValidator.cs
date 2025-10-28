namespace CredentialsValidator.Validators;

public class PasswordValidator : IValidator<string>
{
    private static readonly char[] ValidAlphaLower = Enumerable.Range('a', 'z' - 'a' + 1).Select(x => (char)x).ToArray();
    private static readonly char[] ValidAlphaUpper = Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => (char)x).ToArray();
    private static readonly char[] ValidNumericChars = Enumerable.Range('0', '9' - '0' + 1).Select(x => (char)x).ToArray();
    private static readonly char[] ValidSpecSymbolsChars = "!#$%&()*+,-./:;<=>?@^_{}|".ToCharArray();

    private static readonly char[] ValidChars = ValidAlphaLower
        .Concat(ValidAlphaUpper)
        .Concat(ValidNumericChars)
        .Concat(ValidSpecSymbolsChars)
        .ToArray();

    private const int MinLen = 7;
    private const int MaxLen = 50;

    public bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < MinLen)
        {
            return false;
        }

        if (value.Length > MaxLen)
        {
            return false;
        }

        if (!value.All(c => ValidChars.Contains(c)))
        {
            return false;
        }

        if (!value.Any(c => ValidAlphaUpper.Contains(c)))
        {
            return false;
        }

        if (!value.Any(c => ValidNumericChars.Contains(c)))
        {
            return false;
        }

        if (!value.Any(c => ValidSpecSymbolsChars.Contains(c)))
        {
            return false;
        }

        return true;
    }
}
