using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IRegisterCustomer
{
    Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)> Register(CustomerDto customerDto, PrivateInfoDto privateInfo);
}