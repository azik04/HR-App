using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Query.GetAll;

public class GetAllContactUsQueryHandler : IRequestHandler<GetAllContactUsQuery, GenericResponse<List<GetAllContactUsDto>>>
{
    private readonly IGenericRepository<Domain.Entities.ContactUs> _contactUsRepository;
    public GetAllContactUsQueryHandler(
        IGenericRepository<Domain.Entities.ContactUs> contactUsRepository)
        => _contactUsRepository = contactUsRepository;


    public async Task<GenericResponse<List<GetAllContactUsDto>>> Handle(
        GetAllContactUsQuery request, 
        CancellationToken cancellationToken)
    {
        var data = await _contactUsRepository.GetAllAsync();

        var dto = data
            .Select(x => new GetAllContactUsDto
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
                Title = x.Title
            }).ToList();

        return GenericResponse<List<GetAllContactUsDto>>.Ok(dto);
    }
}
