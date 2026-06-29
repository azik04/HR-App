namespace App.Application.Common.Responses.Base;

public class ErrorResponse
{
    public string Message { get; set; }
    public string? StackTrace { get; set; }
}
