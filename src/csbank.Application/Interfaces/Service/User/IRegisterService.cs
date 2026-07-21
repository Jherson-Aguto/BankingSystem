using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IRegisterCustomerService
{
    Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)> CustomerAsync
    (CustomerDto customerDto, PrivateInfoDto privateInfo);
}