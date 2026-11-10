using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Create;

public sealed record class CreateServiceCommand(string Name) : 
    IRequest<GenericResponse<bool>>;