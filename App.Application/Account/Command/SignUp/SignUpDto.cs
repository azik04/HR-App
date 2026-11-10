namespace App.Application.Account.Command.SignUp;

public class SignUpDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public string Pin { get; set; }
}
