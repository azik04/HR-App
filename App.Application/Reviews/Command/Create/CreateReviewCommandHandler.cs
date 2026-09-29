using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Reviews.Command.Create;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.Main.Reviews> _reviewRepository;
    private readonly IGenericRepository<ReviewFiles> _reviewFileRepository;
    private readonly IAppFileService _appFileService;

    public CreateReviewCommandHandler(IGenericRepository<Domain.Entities.Main.Reviews> reviewRepository, IAppFileService appFileService,
        IGenericRepository<ReviewFiles> reviewFileRepository)
    {
        _reviewRepository = reviewRepository;
        _appFileService = appFileService;
        _reviewFileRepository = reviewFileRepository;
    }

    public async Task<GenericResponse<bool>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Main.Reviews()
        {
            ClientId = request.ClientId,
            WorkerId = request.WorkerId,
            Name = request.Name,
            Stars = request.Stars
        };

        await _reviewRepository.InsertAsync(data);

        var insert = await _appFileService.CreateAsync(request.file, Domain.Enums.FileTypes.Review);

        if (insert?.Data == null || !insert.Data.Any())
            return GenericResponse<bool>.Fail("File upload failed");

        foreach (var item in insert.Data)
        {
            var photo = new ReviewFiles
            {
                ReviewId = data.Id,
                FilePath = item
            };

            await _reviewFileRepository.InsertAsync(photo, cancellationToken);
        }
        return GenericResponse<bool>.Ok(true);
    }
}
