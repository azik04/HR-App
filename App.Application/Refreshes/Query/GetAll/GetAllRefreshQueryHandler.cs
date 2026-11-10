using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Refreshes.Query.GetAll;

public class GetAllRefreshQueryHandler : IRequestHandler<GetAllRefreshQuery, GenericResponse<List<GetAllRefreshDto>>>
{
    private readonly IRefreshService _refreshService;
    public GetAllRefreshQueryHandler(IRefreshService refreshService)
        =>_refreshService = refreshService;
    

    public async Task<GenericResponse<List<GetAllRefreshDto>>> Handle(GetAllRefreshQuery request, CancellationToken cancellationToken)
    {
        return await _refreshService.GetAllAsync();
    }
}
