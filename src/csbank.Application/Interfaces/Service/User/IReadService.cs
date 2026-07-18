using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IReadUserService
{
    Task<UserDetailsDto> ByIdAsync(Guid id);
}