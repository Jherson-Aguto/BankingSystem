using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class UpdateUserService(IUpdateUserRepository userRepository) : IUpdateUserService
{
    public async Task<UpdateUserRequest?> UpdateUserDetails(UpdateUserRequest? userRequest, CancellationToken cancellationToken)
    {
        var updatedData = await userRepository.UpdateUserDetails(userRequest, cancellationToken);

        if (updatedData is null)
            return null;

        return MapUser.ToDto(updatedData);
    }
}