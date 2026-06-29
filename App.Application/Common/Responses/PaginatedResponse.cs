using App.Application.Common.Responses.Base;

namespace App.Application.Common.Responses;

public class PaginatedResponse<T> : BaseResponse
{
    public IEnumerable<T>? Data { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }

    public bool HasNextPage => PageNumber * PageSize < TotalCount;
    public bool HasPrevPage => PageNumber > 1;


    public static PaginatedResponse<T> Ok(IEnumerable<T>? data, int pageNumber, int pageSize, int totalCount)
    {
        return new PaginatedResponse<T>
        {
            Data = data,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            Success = true,
            Message = "Data retrieved successfully."
        };
    }

    public static PaginatedResponse<T> Fail(string message, string? stackTrace = null)
    {
        return new PaginatedResponse<T>
        {
            Success = false,
            PageNumber = 0,
            PageSize = 0,
            TotalCount = 0,
            Message ="Failed",
            Error = new ErrorResponse
            {
                Message = message,
                StackTrace = stackTrace
            }
        };
    }
}

