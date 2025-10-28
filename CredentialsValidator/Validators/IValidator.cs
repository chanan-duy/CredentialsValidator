namespace CredentialsValidator.Validators;

public interface IValidator<in T>
{
    public bool IsValid(T value);
    public bool IsValidWithProblems(T value, List<string> outProblems);
}
