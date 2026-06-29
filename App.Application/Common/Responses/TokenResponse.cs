using App.Application.Common.Responses.Base;

namespace App.Application.Common.Responses;

public class TokenResponse : BaseResponse
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }

    public static TokenResponse Ok(string accessToken, string refreshToken)
    {
        return new TokenResponse
        {
            Success = true,
            AccessToken = accessToken,
            Message = "Success",
            RefreshToken = refreshToken
        };
    }

    public static TokenResponse Fail(string message, string? stackTrace = null)
    {
        return new TokenResponse
        {
            Success = false,
            Message = "False",
            Error = new ErrorResponse
            {
                Message = message,
                StackTrace = stackTrace
            }
        };
    }
}
