using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Worker.Query.GetById;

public record GetByIdWorkerQuery(Guid id) : 
    IRequest<GenericResponse<GetByIdWorkerDto>>;