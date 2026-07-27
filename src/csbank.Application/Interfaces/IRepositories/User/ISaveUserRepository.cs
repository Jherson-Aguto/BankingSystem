using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ISaveUserRepository
{
    Task<UserDetailsDto?> DetailsAsync(RequestUserDetailsDto requestUserDetailsDto);
}