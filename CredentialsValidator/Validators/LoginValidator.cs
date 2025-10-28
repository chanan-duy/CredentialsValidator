namespace CredentialsValidator.Validators;

public class LoginValidator : IValidator<string>
{
    private static readonly char[] ValidAlphaChars = Enumerable.Range('a', 'z' - 'a' + 1).Select(x => (char)x).ToArray();
    private static readonly char[] ValidNumbersChars = Enumerable.Range('0', '9' - '0' + 1).Select(x => (char)x).ToArray();
    private static readonly char[] ValidSpecSymbolsChars = "-".ToCharArray();

    private static readonly char[] ValidChars = ValidAlphaChars.Concat(ValidNumbersChars).Concat(ValidSpecSymbolsChars).ToArray();

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

        if (!ValidAlphaChars.Contains(value[0]))
        {
            return false;
        }

        if (ValidSpecSymbolsChars.Contains(value[^1]))
        {
            return false;
        }

        if (!value.All(c => ValidChars.Contains(c)))
        {
            return false;
        }

        return true;
    }
}
