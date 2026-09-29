using App.Application.Common.DTO.Job;
using App.Application.Common.DTO.Review;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Reviews.Query.GetAll;

public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GenericResponse<List<GetAllReviewDto>>>
{
    private readonly IGenericRepository<Domain.Entities.Main.Reviews> _reviewRepository;
    private readonly IAccountService _accountService;
    public GetAllReviewQueryHandler(IGenericRepository<Domain.Entities.Main.Reviews> genericRepository,
        IAccountService accountService)
    {
        _reviewRepository = genericRepository;
        _accountService = accountService;
    }


    public async Task<GenericResponse<List<GetAllReviewDto>>> Handle(GetAllReviewQuery query, CancellationToken cancellationToken)
    {
        var user = await _accountService.GetById(query.appId);
        if (user.Data == null)
            return GenericResponse<List<GetAllReviewDto>>.Fail("User not found.");

        if(user.Data.ClientId != null)
            return GenericResponse<List<GetAllReviewDto>>.Fail("Only Workers are allowed to that method.");

        var data = await _reviewRepository
            .Where(x => x.WorkerId == user.Data.WorkerId)
            .Include(x => x.Client)
            .Include(x => x.Worker)
            .Select(item => new GetAllReviewDto()
            {
                ClientId = item.ClientId,
                ClientName = item.Client.Name,
                Id = item.Id,
                Name = item.Name,
                Stars = item.Stars
            }).ToListAsync();

        return GenericResponse<List<GetAllReviewDto>>.Ok(data);
    }
}
