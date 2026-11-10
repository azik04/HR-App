using App.Application.Account.Command.ChangePassword;
using App.Application.Account.Command.ResetPassword;
using App.Application.Account.Command.SignUp;
using App.Application.Account.Query.GetAll;
using App.Application.Common.Responses;
using App.Domain.Enums;

namespace App.Application.Common.Interfaces;

public interface IAccountService
{
    Task<GenericResponse<bool>> AddRoleAsync();
    Task<GenericResponse<bool>> SignUpAsync(SignUpDto dto, Guid? workerId, Guid? clientId);
    Task<GenericResponse<bool>> SentMailAsync(string email, EmailTypes type);
    Task<GenericResponse<bool>> ChangePasswordAsync(string userId, ChangePasswordDto dto);
    Task<GenericResponse<bool>> ConfirmMailAsync(string userId, string token);
    Task<GenericResponse<bool>> ResetPasswordAsync(ResetPasswordDto dto);
    Task<GenericResponse<bool>> BanAsync(string id);

    Task<GenericResponse<GetByIdAccountDto>> GetById(string id);
    Task<PaginatedResponse<GetByIdAccountDto>> GetAllAsync(int pageNumber, int pageSize, string roleId);
}
