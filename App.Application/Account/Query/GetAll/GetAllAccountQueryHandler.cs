using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Query.GetAll;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, PaginatedResponse<GetByIdAccountDto>>
{
    private readonly IAccountService _accountService;
    public GetAllAccountQueryHandler(IAccountService accountService)
        => _accountService = accountService;
    
    
    public async Task<PaginatedResponse<GetByIdAccountDto>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
    {
        return await _accountService.GetAllAsync(request.pageNumber, request.pageSize, request.roleId);
    }
}
