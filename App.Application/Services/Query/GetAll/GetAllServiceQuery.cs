using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Query.GetAll;

public record GetAllServiceQuery : IRequest<GenericResponse<List<GetAllServiceDto>>>;
