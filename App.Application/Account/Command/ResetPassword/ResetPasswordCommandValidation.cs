using FluentValidation;

namespace App.Application.Account.Command.ResetPassword
{
    public class ResetPasswordCommandValidation : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordCommandValidation()
        {
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6).MaximumLength(100);
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().MinimumLength(6).MaximumLength(100)
                .Equal(x => x.NewPassword).WithMessage("Confirm password must match new password.");
        }
    }
}
