using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Query.GetAll;

public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, GenericResponse<List<GetAllServiceDto>>>
{
    private readonly IGenericRepository<Domain.Entities.Services> _genericRepository;
    public GetAllServiceQueryHandler(
        IGenericRepository<Domain.Entities.Services> genericRepository) 
        => _genericRepository = genericRepository;


    public async Task<GenericResponse<List<GetAllServiceDto>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
    {
        var data = await _genericRepository.GetAllAsync();

        var dto = data.Select(item => new GetAllServiceDto
        {
            Id = item.Id,
            Name = item.Name,
        }).ToList();

        return GenericResponse<List<GetAllServiceDto>>.Ok(dto);
    }
}
