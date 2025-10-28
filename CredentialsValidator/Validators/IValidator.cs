namespace CredentialsValidator.Validators;

public interface IValidator<in T>
{
    public bool IsValid(T value);
}
