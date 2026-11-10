using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Domain.Entities;
using App.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetAll;

public class GetAllActiveJobQueryHandler : IRequestHandler<GetAllActiveJobQuery, GenericResponse<List<GetAllJobDto>>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public GetAllActiveJobQueryHandler(IGenericRepository<Jobs> jobRepository) 
        => _jobRepository = jobRepository;


    public async Task<GenericResponse<List<GetAllJobDto>>> Handle(
        GetAllActiveJobQuery request, 
        CancellationToken cancellationToken)
    {
        var data = await _jobRepository
            .Where(x =>
                x.ServiceId == request.serviceId &&
                x.JobStatuses == (JobStatuses)request.statusId)
            .OrderByDescending(x => x.CreateAt)
            .Include(x => x.Client)
            .Include(x => x.Address)
            .Include(x => x.Service)
            .Include(x => x.JobFile)
            .Select(item => new GetAllJobDto
            {
                Id = item.Id,
                AddressId = item.AddressId,
                AdressName = item.Address.Name,
                ServiceId = item.ServiceId,
                ServiceName = item.Service.Name,
                Name = item.Name,
                AppFile = item.JobFile.Select(ph => ph.FilePath).FirstOrDefault(),
            }).ToListAsync(cancellationToken);

        return GenericResponse<List<GetAllJobDto>>.Ok(data);
    }
}
