using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IReadUserService
{
    Task<UserDetailsDto> ByIdAsync(Guid id);
}