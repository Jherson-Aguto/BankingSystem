using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IReadUserRepository
{
    Task<UserDetailsDto>
    ByIdAsync(Guid id);
}