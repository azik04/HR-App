namespace App.Application.Auth.Command.SignIn;

public class SignInDto
{
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? Token { get; init; }
    public int AuthType { get; init; }
}
