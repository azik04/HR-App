using App.Application.Common.Responses.Base;

namespace App.Application.Common.Responses;

public class FileResponse : BaseResponse
{
    public byte[] File { get; init; }

    public static FileResponse Ok(byte[] file)
    {
        return new FileResponse()
        {
            Success = true,
            Message = "Success",
            File = file
        };
    }

    public static FileResponse Fail(string message, string? stackTrace = null)
    {
        return new FileResponse()
        {
            Success = true,
            Message = "Success",
            File = null,
            Error = new ErrorResponse()
            {
                Message = message,
                StackTrace = stackTrace
            }
        };
    }
}
