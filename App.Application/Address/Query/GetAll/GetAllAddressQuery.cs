using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Query.GetAll;

public record GetAllAddressQuery(string appId) : IRequest<GenericResponse<List<GetAllAddressDto>>>;