using CSbank.Domain.Services;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService
(UserDomainService register,
ISaveUserRepository _save) : IRegisterCustomerService
{

    public async Task<UserDetailsDto?>
    CustomerAsync(RequestUserDetailsDto requestUserDetailsDto)
    {
        register.RegisterCustomerPrivateInfo(requestUserDetailsDto.BirthDate);

        return await _save.DetailsAsync(requestUserDetailsDto);
    }
}