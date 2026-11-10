namespace App.Application.Account.Command.ResetPassword;

public class ResetPasswordDto
{
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
    public string UserId { get; set; }
    public string Token { get; set; }
}
