using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Auth.Command.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, TokenResponse>
{
    private readonly IAuthService _authService;
    public SignInCommandHandler (IAuthService authService)
        => _authService = authService; 
    

    public async Task<TokenResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await _authService.SignInAsync(request.Dto);
    }
}
