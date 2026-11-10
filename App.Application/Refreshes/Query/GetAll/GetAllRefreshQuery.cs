using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Refreshes.Query.GetAll;

public sealed record GetAllRefreshQuery 
    : IRequest<GenericResponse<List<GetAllRefreshDto>>> { }
