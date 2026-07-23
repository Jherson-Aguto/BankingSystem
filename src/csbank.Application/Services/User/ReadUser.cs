using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class ReadUserService(IReadUserRepository read) : IReadUserService
{
    public async Task<UserDetailsDto> ByIdAsync(Guid id)
    {
        return await read.ByIdAsync(id);
    }
}