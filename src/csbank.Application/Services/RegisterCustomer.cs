using CSbank.Domain.Services;
using CSBank.Application.Interfaces;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService : IRegisterCustomer
{
    private readonly RegisterServiceDomain register = new();
    
    public async Task Register(CustomerDto customerDto, PrivateInfoDto privateInfo)
    {
        await register.RegisterCustomerDetails(Map.ToDomain(customerDto));
        await register.RegisterCustomerPrivateInfo(Map.ToDomain(privateInfo));
    }
}