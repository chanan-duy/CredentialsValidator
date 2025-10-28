using CredentialsValidator.Validators;

namespace CredentialsValidator;

internal static class Program
{
    private static void Main(string[] _)
    {
        var val = new LoginValidator();

        Console.WriteLine(val.IsValid("a"));
    }
}
