using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Client.Query.GetById;

public record GetByIdClientQuery(Guid id) : IRequest<GenericResponse<GetByIdClientDto>>;
