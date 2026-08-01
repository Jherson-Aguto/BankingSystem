using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class UpdateUserService(IUpdateUserRepository userRepository) : IUpdateUserService
{
    public async Task<UpdateUserRequest?> UpdateUserDetails(UpdateUserRequest? userRequest)
    {
        var updatedData = await userRepository.UpdateUserDetails(userRequest);

        if (updatedData is null)
            return null;

        return MapUser.ToDto(updatedData);
    }
}