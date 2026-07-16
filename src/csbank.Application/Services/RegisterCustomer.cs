using CSbank.Domain.Services;
using CSBank.Application.Interfaces;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService(RegisterServiceDomain register) : IRegisterCustomer
{

    public async Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)>
    Register(CustomerDto customerDto, PrivateInfoDto privateInfo)
    {
        var customerData = await register.RegisterCustomerDetails(Map.ToDomain(customerDto));
        var privateInfoData = await register.RegisterCustomerPrivateInfo(Map.ToDomain(privateInfo));

        return (customerData: Map.ToDto(customerData), privateInfoData: Map.ToDto(privateInfoData));
    }
}