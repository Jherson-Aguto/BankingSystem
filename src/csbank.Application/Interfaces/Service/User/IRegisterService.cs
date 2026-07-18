using CSBank.Application.Models;

namespace CSBank.Application.Interfaces;

public interface IRegisterService
{
    Task<(CustomerDto customerData, PrivateInfoDto privateInfoData)> CustomerAsync
    (CustomerDto customerDto, PrivateInfoDto privateInfo);
}