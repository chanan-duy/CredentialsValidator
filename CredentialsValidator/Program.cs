using CredentialsValidator.Validators;

namespace CredentialsValidator;

public static class MainLogic
{
    public static void Run()
    {
        PrintNewLine();
        Console.WriteLine("Credentials validator");
        PrintNewLine();

        RunLogin();

        PrintNewLine();

        RunPassword();
    }

    private static void RunLogin()
    {
        var loginValidator = new LoginValidator();

        Console.WriteLine("Enter login:");
        var login = Console.ReadLine()!;
        Console.WriteLine($"is login valid?: {loginValidator.IsValid(login)}");
    }

    private static void RunPassword()
    {
        var passwordValidator = new PasswordValidator();

        Console.WriteLine("Enter password:");
        var password = Console.ReadLine()!;
        Console.WriteLine($"is password valid?: {passwordValidator.IsValid(password)}");
    }

    private static void PrintNewLine()
    {
        Console.Write(Environment.NewLine);
    }
}

internal static class Program
{
    private static void Main(string[] _)
    {
        MainLogic.Run();
    }
}
