using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ResetPassword;

public sealed record ResetPasswordCommand(ResetPasswordDto dto) : 
    IRequest<GenericResponse<bool>>;

