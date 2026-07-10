using CSbank.Domain.Interfaces;
using CSBank.Application.Interfaces;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterCustomerService(IRegisterCustomer _registerCustomer) : IRegister
{
    public async Task Register(CustomerDto customerDto, PrivateInfoDto privateInfo)
    {
        await _registerCustomer.RegisterCustomerDetails(CustomerMapper.MapToDomain(customerDto));
    }
}