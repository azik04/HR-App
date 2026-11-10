using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    public ResetPasswordCommandHandler(IAccountService accountService)
        => _accountService = accountService;


    public async Task<GenericResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.ResetPasswordAsync(request.dto);
    }
}
