using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using App.Application.WorkerJob.Query.GetAll;
using App.Application.WorkerJobHistory.Query.GetAll;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Job.Query.GetById;

public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQuery, GenericResponse<GetByIdJobDto>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<WorkerJobHistories> _workerJobHistoryRepository;
    public GetByIdJobQueryHandler(IGenericRepository<Jobs> jobRepository, IGenericRepository<WorkerJobHistories> workerJobHistoryRepository)
    { 
        _jobRepository = jobRepository; 
        _workerJobHistoryRepository = workerJobHistoryRepository;
    }
 
    public async Task<GenericResponse<GetByIdJobDto>> Handle(GetByIdJobQuery request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(
            request.id,
            q => q
                .Include(j => j.Address)
                .Include(j => j.Client)
                .Include(j => j.Service)
                .Include(j => j.JobFile)
                .Include(j => j.WorkerJob)
                    .ThenInclude(wj => wj.Workers)
                .Include(j => j.WorkerJobHistory)
                    .ThenInclude(wj => wj.Workers),
            cancellationToken
        );

        var dto = new GetByIdJobDto
        {
            AddressId = item.AddressId,
            AdressName = item.Address.Name,
            Lat = item.Address.Lat,
            Lng = item.Address.Lng,
            Description = item.Description,
            ClientId = item.ClientId,
            ClientName = item.Client.Name + " " + item.Client.Surname,
            ServiceId = item.ServiceId,
            ServiceName = item.Service.Name,
            Status = item.JobStatuses.ToString(),
            Name = item.Name,
            AppFile = item.JobFile.Select(ph => ph.FilePath).ToList(),
            WorkerJob = item.WorkerJob.Select(wj => new GetAllWorkerJobDto
            {
                Status = wj.Status.ToString(),
                Id = wj.Id,
                WorkerId = wj.WorkerId,
                WorkerName = wj.Workers.Name + " " + wj.Workers.Surname,
                FinishAt = wj.FinishAt?.ToString("dd:MM:yyyy HH:mm"),
                CreateAt = wj.CreateAt.ToString("dd:MM:yyyy HH:mm"),
                JobId = item.Id,
                JobName = item.Name,
            }).FirstOrDefault(),
            WorkerJobHistory = item.WorkerJobHistory.Select(wj => new GetAllWorkerJobHistoryDto
            {
                Status = wj.Status.ToString(),
                Id = wj.Id,
                WorkerId = wj.WorkerId,
                WorkerName = wj.Workers.Name + " " + wj.Workers.Surname,
                FinishAt = wj.FinishAt?.ToString("dd:MM:yyyy HH:mm"),
                CreateAt = wj.CreateAt.ToString("dd:MM:yyyy HH:mm"),
                JobId = item.Id,
                JobName = item.Name,
            }).OrderByDescending(x => x.CreateAt).ToList(),

        };

        return GenericResponse<GetByIdJobDto>.Ok(dto);
    }
}
