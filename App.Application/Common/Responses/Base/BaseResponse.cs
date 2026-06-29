namespace App.Application.Common.Responses.Base;

public abstract class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ErrorResponse? Error { get; set; }
}

