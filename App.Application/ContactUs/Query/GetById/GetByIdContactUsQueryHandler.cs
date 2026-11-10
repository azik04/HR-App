using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Query.GetById;

public class GetByIdContactUsQueryHandler : 
    IRequestHandler<GetByIdContactUsQuery, GenericResponse<GetByIdContactUsDto>>
{
    private readonly IGenericRepository<Domain.Entities.ContactUs> _contactUsRepository;
    public GetByIdContactUsQueryHandler(
        IGenericRepository<Domain.Entities.ContactUs> contactUsRepository)
        => _contactUsRepository = contactUsRepository;
    
    public async Task<GenericResponse<GetByIdContactUsDto>> Handle(GetByIdContactUsQuery request, CancellationToken cancellationToken)
    {
        var data = await _contactUsRepository.GetByIdAsync(request.Id);

        var dto = new GetByIdContactUsDto
        {
            Id = data.Id,
            Email = data.Email,
            FullName = data.FullName,
            Title = data.Title
        };

        return GenericResponse<GetByIdContactUsDto>.Ok(dto);
    }
}
