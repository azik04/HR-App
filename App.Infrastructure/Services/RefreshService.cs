using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Application.Refreshes.Query.GetAll;
using App.Infrastructure.Identity;

namespace App.Infrastructure.Services;

public class RefreshService : IRefreshService
{
    private readonly IGenericRepository<Refreshes> _refreshRepository;
    public RefreshService(IGenericRepository<Refreshes> refreshRepository)
        => _refreshRepository = refreshRepository;
    
    
    public async Task<GenericResponse<List<GetAllRefreshDto>>> GetAllAsync()
    {
        var data = await _refreshRepository.GetAllAsync();

        var result = data
            .GroupBy(x => x.ExpireDate.Date)
            .Select(g => new GetAllRefreshDto()
            {
                Date = g.Key.ToString("dd:MM:yyyy"),
                RefreshCount = g.Count()
            })
            .OrderBy(x => x.Date)
            .ToList();

        return GenericResponse<List<GetAllRefreshDto>>.Ok(result);
    }
}