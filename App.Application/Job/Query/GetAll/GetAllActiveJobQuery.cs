using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAll;

public record GetAllActiveJobQuery(int? serviceId, int statusId) : IRequest<GenericResponse<List<GetAllJobDto>>>;
