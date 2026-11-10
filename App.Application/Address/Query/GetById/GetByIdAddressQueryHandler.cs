using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using MediatR;

namespace App.Application.Address.Query.GetById;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GenericResponse<GetByIdAddressDto>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;

    public GetByIdAddressQueryHandler(
        IGenericRepository<Addresses> addressRepository)
        => _addressRepository = addressRepository;
    
    
    public async Task<GenericResponse<GetByIdAddressDto>> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var data = await _addressRepository.GetByIdAsync(request.id, null, cancellationToken);
        if (data == null)
            return GenericResponse<GetByIdAddressDto>.Ok(null);

        var dto = new GetByIdAddressDto()
        {
            Address = data.Address,
            Id = data.Id,
            Name = data.Name,
            Lat = data.Lat,
            Lng = data.Lng
        };

        return GenericResponse<GetByIdAddressDto>.Ok(dto);
    }
}