using CSBank.Domain.Services;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService
(UserDomainService register,
IPasswordService passwordService,
ISaveUserRepository _save) : IRegisterCustomerService
{

    public async Task<UserDetailsDto?>
    CustomerAsync(RequestUserDetailsDto requestUserDetailsDto)
    {
        string password = passwordService.Hash(requestUserDetailsDto.Password);

        requestUserDetailsDto = requestUserDetailsDto with
        {
            Password = password
        };

        register.RegisterCustomerPrivateInfo(requestUserDetailsDto.BirthDate);

        return await _save.DetailsAsync(requestUserDetailsDto);
    }
}