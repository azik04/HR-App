using App.Application.Common.Responses;
using App.Application.Refreshes.Query.GetAll;

namespace App.Application.Common.Interfaces;

public interface IRefreshService
{
    Task<GenericResponse<List<GetAllRefreshDto>>> GetAllAsync();
}