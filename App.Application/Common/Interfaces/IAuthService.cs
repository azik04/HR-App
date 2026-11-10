using App.Application.Auth.Command.SignIn;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces;

public interface IAuthService
{
    Task<TokenResponse> SignInAsync(SignInDto dto);
    Task<GenericResponse<string>> GenerateAccessTokenAsync(string refrashToken);
    Task<GenericResponse<bool>> SignOutAsync(string refrashToken);
}
