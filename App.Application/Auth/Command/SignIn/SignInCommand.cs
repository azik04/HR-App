using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignIn;

public sealed record SignInCommand(SignInDto Dto) : IRequest<TokenResponse>;
