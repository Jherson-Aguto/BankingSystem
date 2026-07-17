using CSbank.Domain.Services;
using CSBank.Application.Interfaces;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService
(RegisterServiceDomain register,
ISaveUserDetailsRepository _save) : IRegisterCustomer
{

    public async Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)>
    Register(CustomerDto customerDto, PrivateInfoDto privateInfo)
    {
        var customerData = await register.RegisterCustomerDetails(Map.ToDomain(customerDto));
        var privateInfoData = await register.RegisterCustomerPrivateInfo(Map.ToDomain(privateInfo));

        var customerResults = Map.ToDto(customerData);
        var privateInfoResults = Map.ToDto(privateInfoData);

        await _save.SaveCustomerDetailsAsync(customerResults, privateInfoResults);

        return (customerData: customerResults, privateInfoData: privateInfoResults);
    }
}