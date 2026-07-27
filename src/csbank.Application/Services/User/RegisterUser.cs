using CSbank.Domain.Services;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService
(UserDomainService register,
ISaveUserRepository _save) : IRegisterCustomerService
{

    public async Task<UserDetailsDto?>
    CustomerAsync(CustomerDto customerDto, PrivateInfoDto privateInfo)
    {
        var customerData = await register.RegisterCustomerDetails(Map.ToDomain(customerDto));
        var privateInfoData = await register.RegisterCustomerPrivateInfo(Map.ToDomain(privateInfo));

        var customerResults = Map.ToDto(customerData);
        var privateInfoResults = Map.ToDto(privateInfoData);

        return await _save.DetailsAsync(customerResults, privateInfoResults);
    }
}