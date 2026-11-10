using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public class SignUpCommand : SignUpDto, IRequest<GenericResponse<bool>>;