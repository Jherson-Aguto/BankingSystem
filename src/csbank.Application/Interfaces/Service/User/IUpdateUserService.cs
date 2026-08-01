using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IUpdateUserService
{
    Task<UpdateUserRequest?> UpdateUserDetails(UpdateUserRequest? userRequest);
}