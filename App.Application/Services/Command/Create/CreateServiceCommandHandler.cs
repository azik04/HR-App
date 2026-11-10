using App.Application.Common.Interfaces.Repository;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Create;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.Services> _genericRepository;
    public CreateServiceCommandHandler(
        IGenericRepository<Domain.Entities.Services> genericRepository) 
        => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Services
        {
            Name = request.Name,
        };

        await _genericRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }
}
