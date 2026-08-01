using CSBank.Application.Models;
using CSBank.Domain.Entities;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IUpdateUserRepository
{
    Task<Customer?> UpdateUserDetails(UpdateUserRequest? updateUser);
}